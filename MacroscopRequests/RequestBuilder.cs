using Macroscop_FaceDB_Importer.Entities.FaceApi;
using Macroscop_FaceDB_Importer.Enums;
using Macroscop_FaceDB_Importer.Forms;
using Macroscop_FaceDB_Importer.Workers;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;

namespace Macroscop_FaceDB_Importer.MacroscopRequests
{
    public class RequestBuilder
    {
        public static Uri BaseAddress { get { return BaseAddress_builder(); } }

        public static HttpRequestMessage New(RequestTypes requestType, FileInfo image = null)
        {
            HttpRequestMessage requestMessage;
            HttpMethod method = HttpMethod.Get;

#nullable enable
            string? contentString = null;
            string? requestString = null;
#nullable restore

            switch (requestType)
            {
                case RequestTypes.FaceApi_InsertImage:

                    method = HttpMethod.Post;
                    requestString = "faces";
                    Person person = new Person();

                    if (!(MainForm.imageNameMask is null))
                    {
                        MatchCollection matches = MainForm.imageNameMask.Matches(image.Name);

                        if (matches.Count > 0)
                        {
                            person.first_name = matches[MainForm.NameMask["first_name"]].Value;
                            person.patronymic = matches[MainForm.NameMask["patronymic"]].Value;
                            person.second_name = matches[MainForm.NameMask["second_name"]].Value;
                        }
                    }

                    var stringImage = Convert.ToBase64String(ImageToByteArray(Image.FromFile(image.FullName)));

                    contentString =                                     $"{{" +
                                                                            $"\"first_name\": \"{person.first_name}\"," +
                                                                            $"\"patronymic\": \"{person.patronymic}\"," +
                                                                            $"\"second_name\": \"{person.second_name}\",";
                                                                         // $"\"additional_info\": null,"
                    if (!(Importer.GroupId is null)) contentString +=       $"\"groups\": " +
                                                                                $"[" +
                                                                                    $"{{" +
                                                                                        $"\"id\": \"{Importer.GroupId}\"" +
                                                                                    $"}}" +
                                                                                $"],";
                    contentString +=                                        $"\"face_images\": " +
                                                                                $"[" +
                                                                                    $"\"{stringImage}\"" +
                                                                                $"]" +
                                                                        $"}}";
                    break;

                case RequestTypes.FaceApi_GetGroups:

                    method = HttpMethod.Get;
                    requestString = "faces-groups";

                    break;

                case RequestTypes.FaceApi_InsertGroup:

                    method = HttpMethod.Post;
                    requestString = "faces-groups";
                    contentString = $"{{" +
                                            $"\"name\": \"{MainForm.GroupName}\"," +
                                        $"}}";
                    break;
            }

            requestMessage = new HttpRequestMessage(method,
                $"api/{requestString}?module={MainForm.MacroscopModule.ToString().ToLower()}") { };

            if (contentString != null)
                requestMessage.Content = new StringContent(contentString, Encoding.UTF8, "application/json");

            var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(
                $"{MainForm.MacroscopLogin}:{CreateMD5(MainForm.MacroscopPassword)}"));

            requestMessage.Headers.Add("Authorization", $"Basic {credentials}");

            return requestMessage;
        }

        private static Uri BaseAddress_builder()
        {
            ConnectionTypes connectionType;

            switch (MainForm.MacroscopSecureConnection)
            {
                case true:
                    connectionType = ConnectionTypes.https;
                    break;
                case false:
                    connectionType = ConnectionTypes.http;
                    break;
            }

            return new Uri(
                $"{connectionType}://" +
                $"{MainForm.MacroscopAddress}:" +
                $"{MainForm.MacroscopPort}"
                );
        }

        private static string CreateMD5(string input)
        {
            using System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
                sb.Append(hashBytes[i].ToString("X2", CultureInfo.CurrentCulture));

            return sb.ToString();
        }

        public static byte[] ImageToByteArray(Image image)
        {
            using var ms = new MemoryStream();
            image.Save(ms, image.RawFormat);
            return ms.ToArray();
        }
    }
}
