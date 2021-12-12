using System;
using Microsoft.AspNetCore.Components;
using Shared.X.Responses;
using Toastr;
using Serti.Client.X.Extensions;
using Shared.Menu.Queries.GetMenusUserLogin;
using Shared.Menu.Resources;

namespace Serti.Client.Api
{
    public class MenuApi
    {

        private readonly HttpClient _client;
        private readonly Appsettings _appsettings;
        private readonly NavigationManager _navigationManager;
        private readonly ToastrService _toastrService;

        public MenuApi(ToastrService toastrService, HttpClient client, Appsettings appsettings, NavigationManager navigationManager)
        {

            _toastrService = toastrService;
            _client = client;
            _appsettings = appsettings;
            _navigationManager = navigationManager;
            HttpExtension.HttpExtensionConfigure(_toastrService, _client, _appsettings, _navigationManager);
        }


        public async Task<ResponseBuilder<List<GetMenusUserLoginResponse>>> GetMenusUserLogin(GetMenusUserLoginRequest request)
        {
            var result = await request.GetAsync<List<GetMenusUserLoginResponse>>($"{MenuEndpoint.Menu.GetMenusUserLogin}");
            return result;
        }

    }
}
