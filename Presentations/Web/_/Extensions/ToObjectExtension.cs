using Newtonsoft.Json;

namespace Web._.Extensions
{
    public static class ToObjectExtension
    {
        public static T ToObject<T>(this string result)
        {
            if (result == null)
            { result = ""; }
            var rtn = JsonConvert.DeserializeObject<T>(result);
            return rtn;
        }
    }
}
