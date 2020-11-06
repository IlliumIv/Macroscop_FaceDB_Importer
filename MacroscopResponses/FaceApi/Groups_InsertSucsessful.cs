using Newtonsoft.Json.Linq;

namespace Macroscop_FaceDB_Importer.MacroscopResponses.FaceApi
{
    public class Groups_InsertSucsessful : HttpResponseJsonContent
    {
#pragma warning disable IDE1006 // Naming Styles
        public string id { get; } = JsonBody.id;
        public string external_id { get; } = JsonBody.external_id;
        public string name { get; } = JsonBody.name;
        public string color { get; } = JsonBody.color;
        public bool intercept { get; } = JsonBody.intercept;
        public string modification_time { get; } = JsonBody.modification_time; // "2020-08-01T22:48:17.099Z"
#pragma warning restore IDE1006 // Naming Styles
    }
}
