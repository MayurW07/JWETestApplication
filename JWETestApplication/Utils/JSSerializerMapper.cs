using Jose;
using Newtonsoft.Json;
namespace JWETestApplication.Utils
{
    public class JSSerializerMapper:IJsonMapper
    {
        //private static JsonConvert js;

        //private JsonConvert JS
        //{
        //    get { return js ?? (js = new JsonConvert()); }
        //}

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public T Parse<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}