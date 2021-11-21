using Microsoft.AspNetCore.Components;
using Shared.Event.Queries.GetEvents;

namespace Serti.Client.Pages.Participant
{
    public partial class Index : ComponentBase
    {

        // inject

        // variable
        protected List<GetEventsResponse> _events = null;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await GetEvents();
            }
        }

        private async Task GetEvents()
        {
            var getEvents = await EventApi.EventsGetAsync(new GetEventsRequest());
            if (!getEvents.IsError)
            {
                _events = getEvents.Data;
                StateHasChanged();
            }
        }
    }
}
