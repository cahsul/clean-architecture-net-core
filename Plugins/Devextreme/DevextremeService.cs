using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Devextreme
{
    public class DevextremeService
    {
        private readonly IJSRuntime _jsRuntime;
        public DevextremeService(IJSRuntime jSRuntime)
        {
            _jsRuntime = jSRuntime;
        }


        public async Task DataGrid(string target, string url, string key, string[] columns)
        {
            //await _jsRuntime.InvokeVoidAsync("toastrFunctions.showToastrInfo", message);
            await _jsRuntime.InvokeVoidAsync("DevextremeFunctions.DataGrid", target, url, key, columns);
        }
    }
}
