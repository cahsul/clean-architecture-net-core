using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shared.X.Extensions
{
    public static class JsonExtension
    {
        public static T JsonDeserialize<T>(this string result)
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

        public static string JsonSerialize(this object result)
        {
            return JsonSerializer.Serialize(result);
        }
    }
}
