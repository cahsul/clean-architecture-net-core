using Serti.Client.X.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Serti.Client.Pages.Certificate
{
    public partial class Certificate : ComponentBase
    {
        [Inject] public IJSRuntime JSRuntime { get; set; }

        public ElementReference _divChart;
        public ElementReference _divChart2;

        private IJSObjectReference _jsModule;
        protected override async Task OnInitializedAsync()
        {
            // await _jsModule.InvokeVoidAsync("dashboardReady");

            //await base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _jsModule = await JSRuntime.ReadJsFile<Certificate>();
                await _jsModule.InvokeVoidAsync("fabrik");

            }
        }

        public async Task SaveAsync()
        {
            await _jsModule.InvokeVoidAsync("SaveImage");

        }
    }
}
