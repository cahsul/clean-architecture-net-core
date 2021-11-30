using Blazored.LocalStorage;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Serti.Client.Pages.Identity.Store;
using Shared.Dashboard.Resources;
using Shared.Identity.Queries.LoginByEmail;
using Toastr;

namespace Serti.Client.Pages.Identity.Login
{
    public partial class Login
    {
        // Inject
        [Inject] private ToastrService ToastrService { get; set; }
        [Inject] private NavigationManager NavManager { get; set; }
        [Inject] private IDispatcher Dispatcher { get; set; }


        // global variabel
        protected LoginByEmailRequest _modelForm = new();


        private async Task Submit(EditContext editContext)
        {

            // send to API
            var result = await IdentityApi.Login(_modelForm);

            if (result.IsError == false)
            {
                await ToastrService.Success(result.Message);
                NavManager.NavigateTo(DashboardEndPoint.Dashboard.Home);
            }

            // set jwt token to local storage
            await LocalStorage.SetJwtToken(result.Data.JwtToken);

            // set identity
            Dispatcher.Dispatch(new IdentitySetValueAction(result.Data.Email, "nama_depan", "nama_belakang"));

        }
    }
}
