using Newtonsoft.Json.Linq;

namespace Macroscop_FaceDB_Importer.MacroscopResponses.FaceApi
{
    public class Face_InsertSucsessful : HttpResponseJsonContent
    {
#pragma warning disable IDE1006 // Naming Styles
        public string id { get; } = JsonBody.id;
        public string external_id { get; } = JsonBody.external_id;
        public string first_name { get; } = JsonBody.first_name;
        public string patronymic { get; } = JsonBody.patronymic;
        public string second_name { get; } = JsonBody.second_name;
        public string additional_info { get; } = JsonBody.additional_info;
        public string modification_time { get; } = JsonBody.modification_time; // "2020-08-01T22:48:17.099Z"
        public JArray face_images { get; } = JsonBody.face_images;
        public JArray groups { get; } = JsonBody.groups;
#pragma warning restore IDE1006 // Naming Styles
    }
}
