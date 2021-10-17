using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Shared.Todos.Commands.CreateTodo;
using Shared.Todos.Commands.DeleteTodo;
using Shared.Todos.Queries.GetTodos;
using Shared.Todos.Resources;
using Web._.Extensions;
//using Web.Shared.Components;
using Shared._.Extensions;
using Shared.__.Responses;

namespace Web.Api
{
    public class TodoApi
    {
        private readonly HttpClient _client;
        //private readonly NotificationComponent _notification;

        //public TodoApi(HttpClient client, NotificationComponent notification)
        public TodoApi(HttpClient client)
        {
            _client = client;
            //_notification = notification;
        }

        public async Task<ResponseBuilder<List<GetTodosResponse>>> GetTodosAsync()
        {
            var resulr = await GetAsync(@$"http://localhost:5000/{TodoEndpoint.V1.Todo.Path}");
            return resulr.ToObject<ResponseBuilder<List<GetTodosResponse>>>();
        }

        public async Task<ResponseBuilder<CreateTodoResponse>> CreateTodoAsync(CreateTodoRequest model)
        {
            var data = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var resulr = await PostAsync(@$"http://localhost:5000/{TodoEndpoint.V1.Todo.Create.Path}", data);
            return resulr.ToObject<ResponseBuilder<CreateTodoResponse>>();
        }

        public async Task<ResponseBuilder<DeleteTodoResponse>> DeleteTodoAsync(Guid id)
        {
            var resulr = await DeleteAsync(@$"http://localhost:5000/{TodoEndpoint.V1.Todo.Delete.Path}/{id}");
            return resulr.ToObject<ResponseBuilder<DeleteTodoResponse>>();
        }




        private async Task<string> GetAsync(string url)
        {
            try
            {
                var response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    //await _notification.Error("Gagal Mengambil data dari server..");
                    return null;
                }

                return content;
            }
            catch (Exception ex)
            {
                //await _notification.Error(ex.Message, 0);
                return null;
            }

        }

        private async Task<string> PostAsync(string url, HttpContent httpContent)
        {
            try
            {
                var response = await _client.PostAsync(url, httpContent);
                var content = await response.Content.ReadAsStringAsync();

                var contentObject = content.ToObject<ResponseBuilder<CreateTodoResponse>>();

                // return pesan error yang di dapat dari API
                if (contentObject?.IsError == true && contentObject?.ErrorsMessage?.Count > 0)
                {
                    //await _notification.Error(contentObject.ErrorsMessage.ToString("<br/>"), 0);
                    return null;
                }

                if (!response.IsSuccessStatusCode)
                {
                    //await _notification.Error("Gagal Menyimpan Data..");
                    return null;
                }

                return content;
            }
            catch (Exception ex)
            {
                //await _notification.Error(ex.Message, 0);
                return null;
            }

        }

        private async Task<string> DeleteAsync(string url)
        {
            try
            {
                var response = await _client.DeleteAsync(url);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    //await _notification.Error("Gagal Menghapus Data..");
                    return null;
                }

                return content;
            }
            catch (Exception ex)
            {
                //await _notification.Error(ex.Message, 0);
                return null;
            }

        }
    }
}
