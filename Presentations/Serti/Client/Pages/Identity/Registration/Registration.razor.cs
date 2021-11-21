using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Shared.Identity.Commands.RegisterByEmail;
using Toastr;

namespace Serti.Client.Pages.Identity.Registration
{
    public partial class Registration : ComponentBase
    {

        // Inject
        [Inject] private ToastrService ToastrService { get; set; }


        // global variabel
        protected RegisterByEmailRequest _modelForm = new();
        protected bool _registrationIsSuccess = false;

        private async Task Submit(EditContext editContext)
        {

            // send to API
            var result = await IdentityApi.Registration(_modelForm);

            if (result.IsError == false)
            {
                await ToastrService.Success(result.Message);
                _registrationIsSuccess = true;
            }
        }
    }
}
