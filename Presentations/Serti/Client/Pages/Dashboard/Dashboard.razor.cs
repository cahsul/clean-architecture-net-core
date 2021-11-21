using Serti.Client.X.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Serti.Client.Pages.Dashboard
{
    public partial class Dashboard : ComponentBase
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
                _jsModule = await JSRuntime.ReadJsFile<Dashboard>();
                await _jsModule.InvokeVoidAsync("dashboardReady", _divChart);
                await _jsModule.InvokeVoidAsync("pieChart", _divChart2);


            }
        }
    }
}
