
namespace Macroscop_FaceDB_Importer.MacroscopResponses.FaceApi
{
    public class InsertError : HttpResponseJsonContent
    {
        public string ErrorMessage { get; } = JsonBody.ErrorMessage;
    }
}
