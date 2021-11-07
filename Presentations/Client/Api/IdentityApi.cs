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
using Client.X.Extensions;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Reflection;
using Shared.Identity.Commands.RegisterByEmail;
using Shared.Identity.Resources;

namespace Client.Api
{
    public class IdentityApi
    {

        private readonly HttpClient _client;
        private readonly Appsettings _appsettings;
        private readonly ToastrService _toastrService;

        public IdentityApi(ToastrService toastrService, HttpClient client, Appsettings appsettings)
        {

            _toastrService = toastrService;
            _client = client;
            _appsettings = appsettings;
            HttpExtension.HttpExtensionConfigure(_toastrService, _client);
        }


        public async Task<ResponseBuilder<RegisterByEmailResponse>> Registration(RegisterByEmailRequest request)
        {
            var result = await request.PostAsync<RegisterByEmailResponse>($"{_appsettings.Api_Serti()}{IdentityEndpoint.Identity.Register}");
            return result;
        }


    }
}
