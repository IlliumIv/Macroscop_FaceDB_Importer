using System;
using System.Collections.Generic;
using System.Text;

namespace Macroscop_FaceDB_Importer.MacroscopResponses
{
    public class FaceApi_Insert_Error : HttpResponseJsonContent
    {
        public string ErrorMessage { get; } = JsonBody.ErrorMessage;
    }
}
