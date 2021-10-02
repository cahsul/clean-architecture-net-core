using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Client.Pages.Dashboard
{
    public partial class Index : ComponentBase
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
                _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./app-js/dashboard.js");
                await _jsModule.InvokeVoidAsync("dashboardReady", _divChart);
                await _jsModule.InvokeVoidAsync("pieChart", _divChart2);
            }
        }
    }
}
