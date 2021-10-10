using System.Text.Json;
using System.Text.Json.Serialization;

namespace Client._.Extensions
{
    public static class ToObjectExtension
    {
        public static T ToObject<T>(this string result)
        {
            if (result == null)
            { result = ""; }
            //var rtn = JsonConvert.DeserializeObject<T>(result);
            var rtn = JsonSerializer.Deserialize<T>(result);
            return rtn;
        }
    }
}
