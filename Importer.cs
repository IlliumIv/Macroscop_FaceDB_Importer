using Macroscop_FaceDB_Importer.MacroscopResponses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Security.Authentication;

namespace Macroscop_FaceDB_Importer
{
    public class Importer
    {
        public static event ImporterForm.LogMessageDelegate LogMessage;
        public static event ImporterForm.ProgressBarDelegate PrograssBarValue;

        public static List<FileInfo> ImagesToImport;
        public static HttpClient MacroscopClient;

        private static readonly HttpClientHandler macroscopClientHandler = new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true,
            SslProtocols = SslProtocols.Tls12
        };

        public static void Import()
        {
            switch (ImporterForm.MacroscopSecureConnection)
            {
                case true:
                    MacroscopClient = new HttpClient(macroscopClientHandler)
                    {
                        BaseAddress = RequestBuilder.BaseAddress
                    };

                    break;
                case false:
                    MacroscopClient = new HttpClient
                    {
                        BaseAddress = RequestBuilder.BaseAddress
                    };

                    break;
            }

            if (ImagesToImport is null || ImagesToImport.Count == 0)
                LogMessage("No images found to import");
            else
            {
                int counter = 0;
                foreach (FileInfo image in ImagesToImport)
                {
                    counter++;
                    PrograssBarValue(counter);

                    try
                    {
                        HttpResponseMessage macroscopRawResponse = MacroscopClient.SendAsync(RequestBuilder.FaceApi_InsertImage(image)).Result;
                        string content = macroscopRawResponse.Content.ReadAsStringAsync().Result;

                        if (StringInfo.GetNextTextElement(content, 0) == "{")
                        {
                            var response = new HttpResponseJsonContent(content);
                            var deserializedResponse = response.GetDeserializedResponse();

                            if (deserializedResponse is FaceApi_Insert_Sucsessful)
                            {
                                continue;
                            }
                            else if (deserializedResponse is FaceApi_Insert_Error)
                            {
                                FaceApi_Insert_Error FaceApi_Insert_Error = (FaceApi_Insert_Error)response.GetDeserializedResponse();
                                LogMessage($"{image.Name}:\n\t{FaceApi_Insert_Error.ErrorMessage}");

                                if (FaceApi_Insert_Error.ErrorMessage.Contains("License error:") ||
                                    FaceApi_Insert_Error.ErrorMessage.Contains("Resource is forbidden for user"))
                                {
                                    break;
                                }

                                continue;
                            }
                        }

                        LogMessage(content);
                        break;
                    }
                    catch (Exception e)
                    {
                        LogMessage(e.Message);
                        break;
                    }
                }

                PrograssBarValue(ImagesToImport.Count);
            }
        }

        public static void To_LogMessage(string message)
        {
            LogMessage(message);
        }
    }
}
