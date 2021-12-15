using Macroscop_FaceDB_Importer.Enums;
using Macroscop_FaceDB_Importer.Forms;
using Macroscop_FaceDB_Importer.MacroscopRequests;
using Macroscop_FaceDB_Importer.MacroscopResponses;
using Macroscop_FaceDB_Importer.MacroscopResponses.FaceApi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Security.Authentication;

namespace Macroscop_FaceDB_Importer.Workers
{
    public class Importer
    {
        public static event MainForm.LogMessageDelegate LogMessage;
        public static event MainForm.ProgressBarDelegate PrograssBarValue;
        public static event MainForm.ImportStatus ImportStatus;

        public static List<FileInfo> ImagesToImport;
        public static HttpClient MacroscopClient;

        public static int SuccessCounter;
        public static string GroupId;

        public static bool DoWork;

        private static readonly HttpClientHandler macroscopClientHandler = new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true,
            SslProtocols = SslProtocols.Tls12
        };

        public static void Import()
        {
            switch (MainForm.MacroscopSecureConnection)
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
                DoWork = true;
                ImportStatus(true);

                Stopwatch stopwatch = Stopwatch.StartNew();

                if (MainForm.GroupName != "")
                {
                    try
                    {
                        HttpResponseMessage macroscopRawResponse = MacroscopClient.SendAsync(RequestBuilder.New(RequestTypes.FaceApi_GetGroups)).Result;
                        string content = macroscopRawResponse.Content.ReadAsStringAsync().Result;

                        if (StringInfo.GetNextTextElement(content, 0) == "{")
                        {
                            var response = new HttpResponseJsonContent(content);
                            var deserializedResponse = response.GetDeserializedResponse();

                            if (deserializedResponse is Groups_List)
                            {
                                var list = (Groups_List)deserializedResponse;
                                for (int i = 0; i < list.groups.Count; i++)
                                {
                                    if (MainForm.GroupName == (string)response.GetDynamicBody().groups[i].name)
                                        GroupId = (string)response.GetDynamicBody().groups[i].id;
                                }
                            }
                        }

                        if (GroupId is null)
                        {
                            macroscopRawResponse = MacroscopClient.SendAsync(RequestBuilder.New(RequestTypes.FaceApi_InsertGroup)).Result;
                            content = macroscopRawResponse.Content.ReadAsStringAsync().Result;

                            if (StringInfo.GetNextTextElement(content, 0) == "{")
                            {
                                var response = new HttpResponseJsonContent(content);
                                var deserializedResponse = response.GetDeserializedResponse();

                                if (deserializedResponse is Groups_InsertSucsessful)
                                {
                                    Groups_InsertSucsessful groups_InsertSucsessful = (Groups_InsertSucsessful)response.GetDeserializedResponse();
                                    GroupId = groups_InsertSucsessful.id;
                                }
                                else
                                    LogMessage($"Failed to add new group \"{MainForm.GroupName}\":\n{content}");
                            }
                        }
                    }
                    catch (Exception e) { LogMessage($"{e.Message}\n{e.StackTrace}"); }
                }

                int counter = 0;
                SuccessCounter = 0;

                foreach (FileInfo image in ImagesToImport)
                {
                    if (!DoWork)
                        break;

                    counter++;
                    PrograssBarValue(counter);

                    try
                    {
                        LogMessage($"{image.FullName}", true);
                        var req = RequestBuilder.New(RequestTypes.FaceApi_InsertImage, image);
                        HttpResponseMessage macroscopRawResponse = MacroscopClient.SendAsync(req).Result;
                        string content = macroscopRawResponse.Content.ReadAsStringAsync().Result;

                        if (StringInfo.GetNextTextElement(content, 0) == "{")
                        {
                            var response = new HttpResponseJsonContent(content);
                            var deserializedResponse = response.GetDeserializedResponse();

                            if (deserializedResponse is Face_InsertSucsessful)
                            {
                                SuccessCounter++;
                                continue;
                            }
                            else if (deserializedResponse is Error)
                            {
                                Error FaceApi_Insert_Error = (Error)response.GetDeserializedResponse();
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
                        (string message, bool shouldContinue) error = e switch
                        {
                            OutOfMemoryException => ($"{image.FullName}:\n\tWrong image format.", true),
                            _ => ($"{e.Message}\n{e.StackTrace}", false),
                        };

                        LogMessage(error.message);

                        if (error.shouldContinue) continue;
                        else break;
                    }
                }
                LogMessage($"Time spent: {stopwatch.Elapsed}");

                PrograssBarValue(SuccessCounter);
                ImportStatus(false);
            }
        }
    }
}
