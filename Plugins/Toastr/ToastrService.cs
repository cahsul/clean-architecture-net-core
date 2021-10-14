using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Toastr
{
    public class ToastrService
    {
        private readonly IJSRuntime _jsRuntime;
        public ToastrService(IJSRuntime jSRuntime)
        {
            _jsRuntime = jSRuntime;
        }

        public async Task ShowInfoMessage(string message)
        {
            await _jsRuntime.InvokeVoidAsync("toastrFunctions.showToastrInfo", message);
        }
    }
}
