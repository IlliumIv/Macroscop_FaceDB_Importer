using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Macroscop_FaceDB_Importer.MacroscopResponses.FaceApi;

namespace Macroscop_FaceDB_Importer.MacroscopResponses
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
                Response = new InsertSucsessful();
                return;
            }
            catch (ArgumentNullException) { }

            try
            {
                Response = new InsertError();
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
