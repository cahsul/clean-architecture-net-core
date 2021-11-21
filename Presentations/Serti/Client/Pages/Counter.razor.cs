using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Shared.Event.Queries.GetEvents;
using Shared.Identity.Queries.GetToken;
using Shared.Identity.Queries.LoginByEmail;

namespace Serti.Client.Pages
{
    public partial class Counter
    {
        [Inject] private HttpClient Http { get; set; }

        private int _currentCount = 0;

        private void IncrementCount()
        {
            _currentCount++;
        }

        private async Task LoginAsync()
        {


            var aaaaa = await IdentityApi.Login(new LoginByEmailRequest { Email = "a@a.com", Password = "a", });
            //  var forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("WeatherForecastz");
        }

        private async Task GetToken()
        {
            var aaaaa = await IdentityApi.GetToken(new GetTokenRequest { });
        }

        private async Task GetEvent()
        {
            var aaaaa = await EventApi.EventsGetAsync(new GetEventsRequest { });
        }
    }
}
