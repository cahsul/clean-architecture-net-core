using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Shared.X.Enums;
using Shared.X.Extensions;
using Shared.X.Responses;
using Shared.Event.Commands.EventCreate;
using Shared.Event.Resources;
using Toastr;
using Client.X.Extensions;
using Microsoft.Extensions.Configuration;

namespace Client.Api
{
    public class EventApi
    {

        private readonly HttpClient _client;
        private readonly Appsettings _appsettings;
        private readonly ToastrService _toastrService;

        public EventApi(ToastrService toastrService, HttpClient client, Appsettings appsettings)
        {

            _toastrService = toastrService;
            _client = client;
            _appsettings = appsettings;
            HttpExtension.HttpExtensionConfigure(_toastrService, _client);
        }

        //public async Task<ResponseBuilder<List<GetTodosResponse>>> GetTodosAsync()
        //{
        //    var resulr = await GetAsync(@$"http://localhost:5000/{TodoEndpoint.V1.Todo.Path}");
        //    return resulr.ToObject<ResponseBuilder<List<GetTodosResponse>>>();
        //}

        public async Task<ResponseBuilder<EventCreateResponse>> CreateAsync(EventCreateRequest request)
        {
            var result = await request.PostAsync<EventCreateResponse>($"{_appsettings.Api_Serti()}/{EventEndpoint.V1.Event.Create.Path}"); // TODO : url hardcode
            return result;
        }

        //public async Task<ResponseBuilder<DeleteTodoResponse>> DeleteTodoAsync(Guid id)
        //{
        //    var resulr = await DeleteAsync(@$"http://localhost:5000/{TodoEndpoint.V1.Todo.Delete.Path}/{id}");
        //    return resulr.ToObject<ResponseBuilder<DeleteTodoResponse>>();
        //}




        //private async Task<string> GetAsync(string url)
        //{
        //    try
        //    {
        //        var response = await _client.GetAsync(url);
        //        response.EnsureSuccessStatusCode();
        //        var content = await response.Content.ReadAsStringAsync();

        //        if (!response.IsSuccessStatusCode)
        //        {
        //            //await _notification.Error("Gagal Mengambil data dari server..");
        //            return null;
        //        }

        //        return content;
        //    }
        //    catch (Exception ex)
        //    {
        //        //await _notification.Error(ex.Message, 0);
        //        return null;
        //    }

        //}



        //private async Task<string> DeleteAsync(string url)
        //{
        //    try
        //    {
        //        var response = await _client.DeleteAsync(url);
        //        response.EnsureSuccessStatusCode();
        //        var content = await response.Content.ReadAsStringAsync();

        //        if (!response.IsSuccessStatusCode)
        //        {
        //            //await _notification.Error("Gagal Menghapus Data..");
        //            return null;
        //        }

        //        return content;
        //    }
        //    catch (Exception ex)
        //    {
        //        //await _notification.Error(ex.Message, 0);
        //        return null;
        //    }

        //}
    }
}
