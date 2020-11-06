
namespace Macroscop_FaceDB_Importer.MacroscopResponses.FaceApi
{
    public class Error : HttpResponseJsonContent
    {
        public string ErrorMessage { get; } = JsonBody.ErrorMessage;
    }
}
