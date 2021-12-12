using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shared.Menu.Queries.GetMenusUserLogin;
using Shared.X.Responses;

namespace Serti.Client.SharedPage.Layout
{
    public partial class NavMenu
    {

        [Inject] public IJSRuntime JSRuntime { get; set; }
        private IJSObjectReference _jsModule;

        private ResponseBuilder<List<GetMenusUserLoginResponse>> UserMenus { get; set; }
    }
}
