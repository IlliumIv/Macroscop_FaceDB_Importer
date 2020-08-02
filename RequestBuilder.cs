using Macroscop_FaceDB_Importer.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;

namespace Macroscop_FaceDB_Importer
{
    public class RequestBuilder
    {
        public static event ImporterForm.SetNameMaskDelegate SetNameMask;

        public static Uri BaseAddress { get { return BaseAddress_builder(); } }

        public static HttpRequestMessage FaceApi_InsertImage(FileInfo image)
        {
            string first_name = "";
            string patronymic = "";
            string second_name = "";

            if (!(ImporterForm.imageNameMask is null))
            {
                MatchCollection matches = ImporterForm.imageNameMask.Matches(image.Name);

                if (matches.Count > 0)
                {
                    SetNameMask();
                    try
                    {
                        first_name = matches[ImporterForm.NameMask["first_name"]].Value;
                        patronymic = matches[ImporterForm.NameMask["patronymic"]].Value;
                        second_name = matches[ImporterForm.NameMask["second_name"]].Value;
                    }
                    catch (Exception e)
                    {

                    }
                }
            }

            HttpRequestMessage insertImage = new HttpRequestMessage(HttpMethod.Post, $"api/faces?module={ImporterForm.MacroscopModule.ToString().ToLower()}")
            {
                Content = new StringContent(
                    $"{{" +
                        $"\"first_name\": \"{first_name}\"," +
                        $"\"patronymic\": \"{patronymic}\"," +
                        $"\"second_name\": \"{second_name}\"," +
                        // $"\"additional_info\": null," +
                        $"\"face_images\": " +
                            $"[" +
                                $"\"{Convert.ToBase64String(ImageToByteArray(Image.FromFile(image.FullName)))}\"" +
                            $"]" +
                    $"}}",
                    Encoding.UTF8,
                    "application/json"
                    )
            };

            insertImage.Headers.Add("Authorization", $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{ImporterForm.MacroscopLogin}:{CreateMD5(ImporterForm.MacroscopPassword)}"))}");

            return insertImage;
        }

        private static Uri BaseAddress_builder()
        {
            ConnectionTypes connectionType;

            switch (ImporterForm.MacroscopSecureConnection)
            {
                case true:
                    connectionType = ConnectionTypes.https;

                    break;
                case false:
                    connectionType = ConnectionTypes.http;

                    break;
            }

            return new Uri(
                $"{connectionType.ToString()}://" +
                $"{ImporterForm.MacroscopAddress}:" +
                $"{ImporterForm.MacroscopPort}"
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
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
    }
}
