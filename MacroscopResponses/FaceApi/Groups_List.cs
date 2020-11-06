using Newtonsoft.Json.Linq;

namespace Macroscop_FaceDB_Importer.MacroscopResponses.FaceApi
{
    public class Groups_List : HttpResponseJsonContent
    {
#pragma warning disable IDE1006 // Naming Styles
        public int? offset { get; } = JsonBody.offset;
        public int? portion { get; } = JsonBody.portion;
        public int? total_count { get; } = JsonBody.total_count;
        public JArray groups { get; } = JsonBody.groups;
#pragma warning restore IDE1006 // Naming Styles
    }
}
