using Devextreme;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Serti.Client.X.Extensions;
using Shared.Event.Queries.GetEvents;
using Shared.User.Resources;

namespace Serti.Client.Pages.User
{
    public partial class User : ComponentBase
    {
        [Inject] public IJSRuntime JSRuntime { get; set; }
        [Inject] public DevextremeService Dx { get; set; }

        public List<GetEventsResponse> _events = null;
        private IJSObjectReference _jsModule;
        protected override async Task OnInitializedAsync()
        {
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _jsModule = await JSRuntime.ReadJsFile<User>();
                await _jsModule.InvokeVoidAsync("OnAfterRender", UserEndpoint.User.GetUsers);
                await GetUsers();
            }
        }


        private async Task GetUsers()
        {
            string[] columns = { "email" };
            //await Dx.DataGrid("#userTable", UserEndpoint.User.GetUsers, "id", columns);
        }

        [JSInvokable]
        public static void JStoCSCall()
        {
            var content = "C# Method called from JavaScript";
        }
    }
}
