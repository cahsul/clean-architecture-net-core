using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Serti.Client.X.Extensions
{

    public static class JsExtension
    {
        public static async Task<IJSObjectReference> ReadJsFile<T>(this IJSRuntime js)
        where T : ComponentBase
        {
            var type = typeof(T);
            var sb = new StringBuilder("./js-page/");

            var aaa = type.FullName;
            var bbb = type.Assembly.GetName();
            var ccc = type.Assembly.GetName().Name;

            sb.Append(type.FullName.Remove(0, type.Assembly.GetName().Name.Length + 1).Replace(".", "/"));
            sb.Append(".razor.js?" + DateTime.Now.ToString("HHmmss"));

            var result = await js.InvokeAsync<IJSObjectReference>("import", sb.ToString());
            return result;
        }
    }
}
