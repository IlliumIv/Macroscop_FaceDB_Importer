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
        public static event MainForm.LogMessageDelegate LogMessage;

        public static Uri BaseAddress { get { return BaseAddress_builder(); } }

        public static HttpRequestMessage New(RequestTypes requestType, FileInfo image = null)
        {
            (HttpMethod method, string requestString, string contentString) = requestType switch
            {
                RequestTypes.FaceApi_InsertImage => (HttpMethod.Post, "faces", Create_InsertImageContentString(image)),
                RequestTypes.FaceApi_GetGroups => (HttpMethod.Get, "faces-groups", string.Empty),
                RequestTypes.FaceApi_InsertGroup => (HttpMethod.Post, "faces-groups", $"{{\"name\": \"{MainForm.GroupName}\",}}"),
                _ => throw new NotImplementedException(),
            };

            HttpRequestMessage requestMessage = new(method,
                $"api/{requestString}?module={MainForm.MacroscopModule.ToString().ToLower()}") { };

            if (contentString != string.Empty)
                requestMessage.Content = new StringContent(contentString, Encoding.UTF8, "application/json");

            var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(
                $"{MainForm.MacroscopLogin}:{CreateMD5(MainForm.MacroscopPassword)}"));

            requestMessage.Headers.Add("Authorization", $"Basic {credentials}");

            return requestMessage;
        }

        private static string Create_InsertImageContentString(FileInfo imageFileInfo)
        {

            Person person = new();

            if (!(MainForm.imageNameMask is null))
            {
                MatchCollection matches = MainForm.imageNameMask.Matches(imageFileInfo.Name);

                if (matches.Count > 0)
                {
                    person.first_name = matches[MainForm.NameMask["first_name"]].Value;
                    person.patronymic = matches[MainForm.NameMask["patronymic"]].Value;
                    person.second_name = matches[MainForm.NameMask["second_name"]].Value;
                }
            }

            string contentString = $"{{\"first_name\": \"{person.first_name}\"," +
                $"\"patronymic\": \"{person.patronymic}\",\"second_name\": \"{person.second_name}\",";
            // $"\"additional_info\": null,"
            if (!(Importer.GroupId is null)) contentString += $"\"groups\": [{{\"id\": \"{Importer.GroupId}\"}}],";

            using Image image = Image.FromFile(imageFileInfo.FullName);
            string stringImage = Convert.ToBase64String(ImageToByteArray(image));
            contentString += $"\"face_images\": [\"{stringImage}\"]}}";

            return contentString;
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
