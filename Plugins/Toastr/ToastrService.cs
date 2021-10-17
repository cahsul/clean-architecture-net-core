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

        public async Task Warning(string message, ToastrOptions options)
        {
            await _jsRuntime.InvokeVoidAsync("toastrFunctions.warning", message, options);
        }

        public async Task Error(string message, ToastrOptions options)
        {
            await _jsRuntime.InvokeVoidAsync("toastrFunctions.error", message, options);
        }

        public async Task Success(string message)
        {
            var toastrOptions = new ToastrOptions
            {
                CloseButton = true,
                TimeOut = 5000,
                HideMethod = ToastrHideMethod.SlideUp,
                ShowMethod = ToastrShowMethod.SlideDown,
                Position = ToastrPosition.TopRight,
                ShowProgressBar = true,
            };

            await _jsRuntime.InvokeVoidAsync("toastrFunctions.success", message, toastrOptions);
        }

    }
}
