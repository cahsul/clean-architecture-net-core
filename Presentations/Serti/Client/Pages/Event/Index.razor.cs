using Microsoft.AspNetCore.Components;
using Shared.Event.Commands.CreateEvent;
using Shared.Event.Commands.DeleteEvent;
using Shared.Event.Queries.GetEvents;
using Toastr;

namespace Serti.Client.Pages.Event
{
    public partial class Index : ComponentBase
    {

        [Inject] public ToastrService ToastrService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        protected List<GetEventsResponse> _events = null;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await GetEventsAsync();
            }
        }

        private async Task GetEventsAsync()
        {
            var getEvents = await EventApi.EventsGetAsync(new GetEventsRequest());
            if (!getEvents.IsError)
            {
                _events = getEvents.Data;
                StateHasChanged();
            }
        }

        private async void Delete(Guid id)
        {
            var dataToDelete = await EventApi.EventDeleteAsync(new DeleteEventRequest { Id = id });
            if (!dataToDelete.IsError)
            {
                await ToastrService.Success(dataToDelete.Message);
                await GetEventsAsync();
            }
        }

        private async Task CreateAsync()
        {
            var dataToCreate = await EventApi.EventCreateAsync(new CreateEventRequest { });
            if (dataToCreate.IsError)
            { return; }
            NavigationManager.NavigateTo($"/event/update/{dataToCreate.Data.Id}");
        }
    }


}
