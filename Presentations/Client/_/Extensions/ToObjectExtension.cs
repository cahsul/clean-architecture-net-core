using System.Text.Json;
using System.Text.Json.Serialization;

namespace Client._.Extensions
{
    public static class ToObjectExtension
    {
        public static T ToObject<T>(this string result)
        {

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            if (result == null)
            { result = ""; }
            var rtn = JsonSerializer.Deserialize<T>(result, options);
            return rtn;
        }
    }
}
