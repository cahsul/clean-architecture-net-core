using System.Threading.Tasks;
using Client.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Shared.Event.Commands.CreateEvent;
using Shared.Event.Commands.UpdateEvent;
using Shared.Event.Queries.GetEvent;
using Toastr;

namespace Client.Pages.Event.EventUpdate
{

    public partial class EventUpdate : ComponentBase
    {
        [Inject] private IJSRuntime JS { get; set; }
        [Inject] private ToastrService ToastrService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        [Parameter] public Guid Id { get; set; }

        private IJSObjectReference _module;
        protected UpdateEventRequest _updateModel = new();

        public ElementReference _speakerRef;

        private async Task SubmitAsync(EditContext editContext)
        {
            var result = await EventApi.EventUpdateAsync(_updateModel);

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
                // load JS
                _module = await JS.ReadJsFile<EventUpdate>();

                // get data from API
                var getData = await EventApi.EventGetAsync(new GetEventRequest { Id = Id });
                if (getData.IsError)
                { return; }

                // set value to model
                _updateModel.EventName = getData.Data?.EventName;
                _updateModel.Id = getData.Data?.Id;
                StateHasChanged();
            }
        }
    }
}
