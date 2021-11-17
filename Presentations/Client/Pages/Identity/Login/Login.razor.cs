using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Shared.Identity.Queries.LoginByEmail;
using Toastr;

namespace Client.Pages.Identity.Login
{
    public partial class Login
    {
        // Inject
        [Inject] private ToastrService ToastrService { get; set; }
        //[Inject] private ILocalStorageService LocalStorage { get; set; }


        // global variabel
        protected LoginByEmailRequest _modelForm = new();


        private async Task Submit(EditContext editContext)
        {

            // send to API
            var result = await IdentityApi.Login(_modelForm);

            if (result.IsError == false)
            {
                await ToastrService.Success(result.Message);
            }

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            // Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);

            // save token to cookie
            //await LocalStorage.SetItemAsync("name", "John Smith aaaaaaaaaaaaaaaaaaaaaa");
            await LocalStorage.Login();

        }
    }
}
