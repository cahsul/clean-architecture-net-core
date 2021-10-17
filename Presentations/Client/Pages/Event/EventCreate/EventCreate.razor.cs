using System.Threading.Tasks;
using Client.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Shared.Event.Commands.EventCreate;
using Toastr;

namespace Client.Pages.Event.EventCreate
{

    public partial class EventCreate : ComponentBase
    {
        [Inject] private IJSRuntime JS { get; set; }
        [Inject] private ToastrService ToastrService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        private IJSObjectReference _module;
        protected EventCreateRequest _createModel = new();

        public ElementReference _speakerRef;

        private async Task SubmitAsync(EditContext editContext)
        {
            var result = await EventApi.CreateAsync(_createModel);

            if (result.IsError == false)
            {
                await ToastrService.Success(result.Message);
                NavigationManager.NavigateTo("/event"); // TODO : hardcode
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _module = await JS.ReadJsFile<EventCreate>();
            }
        }
    }
}
