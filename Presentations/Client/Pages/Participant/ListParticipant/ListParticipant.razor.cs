using Client.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Client.Pages.Participant.ListParticipant
{
    public partial class ListParticipant : ComponentBase
    {
        [Inject] private IJSRuntime JS { get; set; }
        private IJSObjectReference _jsModule;

        protected ElementReference _dtRef;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                // load JS
                _jsModule = await JS.ReadJsFile<ListParticipant>();
                await _jsModule.InvokeVoidAsync("DatatableLoad", _dtRef);
            }
        }
    }
}
