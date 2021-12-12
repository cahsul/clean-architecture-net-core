using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Serti.Client.X.Extensions;
using Shared.Menu.Resources;

namespace Serti.Client.Pages.Menu.ListMenu
{
    public partial class ListMenu : ComponentBase
    {
        [Inject] public IJSRuntime JSRuntime { get; set; }
        private IJSObjectReference _jsModule;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _jsModule = await JSRuntime.ReadJsFile<ListMenu>();
                await _jsModule.InvokeVoidAsync("OnAfterRender", MenuEndpoint.Menu.Getmenus);
                //await GetUsers();
            }
        }
    }
}
