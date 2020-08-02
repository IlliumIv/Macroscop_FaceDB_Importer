using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Macroscop_FaceDB_Importer.MacroscopResponses;

namespace Macroscop_FaceDB_Importer
{
    public class HttpResponseJsonContent
    {
        protected static dynamic JsonBody { get; private set; }
        private object Response { get; }

        protected HttpResponseJsonContent()
        {
            AllPropertiesExist();
        }

        public HttpResponseJsonContent(string jsonString)
        {
            JsonBody = JsonConvert.DeserializeObject<dynamic>(jsonString);
            Response = JsonBody;

            try
            {
                Response = new FaceApi_Insert_Successful();
                return;
            }
            catch (ArgumentNullException) { }

            try
            {
                Response = new FaceApi_Insert_Error();
                return;
            }
            catch (ArgumentNullException) { }

        }

        public object GetDeserializedResponse()
        {
            return Response;
        }

        public dynamic GetDynamicBody()
        {
            return JsonBody;
        }

        private void AllPropertiesExist()
        {
            JObject obj = (JObject)JsonBody;

            foreach (var property in GetType().GetProperties())
                if (!obj.ContainsKey(property.Name))
                    throw new ArgumentNullException(property.Name);
        }
    }
}
