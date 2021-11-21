using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Shared.X.Enums;
using Shared.X.Extensions;
using Shared.X.Responses;
using Shared.Event.Resources;
using Toastr;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Reflection;
using Shared.Identity.Commands.RegisterByEmail;
using Shared.Identity.Resources;
using Shared.Identity.Queries.LoginByEmail;
using Serti.Client.X.Extensions;
using Shared.Identity.Queries.GetToken;

namespace Serti.Client.Api
{
    public class IdentityApi
    {

        private readonly HttpClient _client;
        private readonly Appsettings _appsettings;
        private readonly NavigationManager _navigationManager;
        private readonly ToastrService _toastrService;

        public IdentityApi(ToastrService toastrService, HttpClient client, Appsettings appsettings, NavigationManager navigationManager)
        {

            _toastrService = toastrService;
            _client = client;
            _appsettings = appsettings;
            _navigationManager = navigationManager;
            HttpExtension.HttpExtensionConfigure(_toastrService, _client, _appsettings, _navigationManager);
        }


        public async Task<ResponseBuilder<RegisterByEmailResponse>> Registration(RegisterByEmailRequest request)
        {
            var result = await request.PostAsync<RegisterByEmailResponse>($"{_appsettings.Api_Serti()}{IdentityEndpoint.Identity.Register}");
            return result;
        }

        public async Task<ResponseBuilder<LoginByEmailResponse>> Login(LoginByEmailRequest request)
        {
            var result = await request.PostAsync<LoginByEmailResponse>($"{_appsettings.Api_Serti()}{IdentityEndpoint.Identity.Login}");
            return result;
        }

        public async Task<ResponseBuilder<GetTokenResponse>> GetToken(GetTokenRequest request)
        {
            var result = await request.PostAsync<GetTokenResponse>($"{_appsettings.Api_Serti()}{IdentityEndpoint.Identity.GetToken}");
            return result;
        }

    }
}
