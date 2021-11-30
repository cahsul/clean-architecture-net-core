using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Shared.X.Responses;
using Toastr;
using Shared.Identity.Commands.RegisterByEmail;
using Serti.Client.X.Extensions;
using Shared.User.Resources;
using Shared.User.Queries.GetProfile;
using Shared.User.Queries.GetUsers;

namespace Serti.Client.Api
{
    public class UserApi
    {

        private readonly HttpClient _client;
        private readonly Appsettings _appsettings;
        private readonly NavigationManager _navigationManager;
        private readonly ToastrService _toastrService;

        public UserApi(ToastrService toastrService, HttpClient client, Appsettings appsettings, NavigationManager navigationManager)
        {

            _toastrService = toastrService;
            _client = client;
            _appsettings = appsettings;
            _navigationManager = navigationManager;
            HttpExtension.HttpExtensionConfigure(_toastrService, _client, _appsettings, _navigationManager);
        }


        public async Task<ResponseBuilder<GetProfileResponse>> GetProfile(GetProfileRequest request)
        {
            var result = await request.GetAsync<GetProfileResponse>($"{_appsettings.Api_Serti()}{UserEndpoint.User.Profile}");
            return result;
        }

        //public async Task<ResponseBuilder<List<GetUsersResponse>>> GetUsers(GetUsersRequest request)
        //{
        //    var result = await request.GetAsync<List<GetUsersResponse>>($"{_appsettings.Api_Serti()}{UserEndpoint.User.GetUsers}");
        //    return result;
        //}


    }
}
