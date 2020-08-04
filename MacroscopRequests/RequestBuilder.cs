using Macroscop_FaceDB_Importer.Entities.FaceApi;
using Macroscop_FaceDB_Importer.Enums;
using Macroscop_FaceDB_Importer.Forms;
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

        public static HttpRequestMessage FaceApi_InsertImage(FileInfo image)
        {
            Person person = new Person();

            if (!(MainForm.imageNameMask is null))
            {
                MatchCollection matches = MainForm.imageNameMask.Matches(image.Name);

                if (matches.Count > 0)
                {
                    foreach (var prop in person.GetType().GetProperties())
                    {
                        try { prop.SetValue(person, matches[MainForm.NameMask[prop.Name]].Value); }
                        catch { }
                    }
                }
            }

            var stringImage = Convert.ToBase64String(ImageToByteArray(Image.FromFile(image.FullName)));

            HttpRequestMessage insertImage_RequestMessage = new HttpRequestMessage(HttpMethod.Post,
                $"api/faces?module={MainForm.MacroscopModule.ToString().ToLower()}")
            {
                Content = new StringContent(
                    $"{{" +
                        $"\"first_name\": \"{person.first_name}\"," +
                        $"\"patronymic\": \"{person.patronymic}\"," +
                        $"\"second_name\": \"{person.second_name}\"," +
                        // $"\"additional_info\": null," +
                        $"\"face_images\": " +
                            $"[" +
                                $"\"{stringImage}\"" +
                            $"]" +
                    $"}}",
                    Encoding.UTF8, "application/json")
            };

            var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(
                $"{MainForm.MacroscopLogin}:{CreateMD5(MainForm.MacroscopPassword)}"));

            insertImage_RequestMessage.Headers.Add("Authorization", $"Basic {credentials}");

            return insertImage_RequestMessage;
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
