using Microsoft.AspNetCore.Components;
using Shared.User.Queries.GetProfile;

namespace Serti.Client.Pages.MyProfile
{
    public partial class MyProfile : ComponentBase
    {
        private GetProfileResponse UserProfile { get; set; }
        protected override async Task OnInitializedAsync()
        {
            var result = await UserApi.GetProfile(new GetProfileRequest());

            if (!result.IsError)
            {
                UserProfile = result.Data;
            }
        }
    }
}
