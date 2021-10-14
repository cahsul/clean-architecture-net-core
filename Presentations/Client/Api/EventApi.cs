using System.Text;
using System.Text.Json;
using Client._.Extensions;
using Shared._.Responses;
using Shared.Event.Commands.EventCreate;
using Shared.Event.Resources;

namespace Client.Api
{
    public class EventApi
    {
        private readonly HttpClient _client;

        public EventApi(HttpClient client)
        {
            _client = client;
        }

        //public async Task<ResponseBuilder<List<GetTodosResponse>>> GetTodosAsync()
        //{
        //    var resulr = await GetAsync(@$"http://localhost:5000/{TodoEndpoint.V1.Todo.Path}");
        //    return resulr.ToObject<ResponseBuilder<List<GetTodosResponse>>>();
        //}

        public async Task<ResponseBuilder<EventCreateResponse>> CreateAsync(EventCreateRequest model)
        {
            var data = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
            var resulr = await PostAsync(@$"http://localhost:5000/{EventEndpoint.V1.Event.Create.Path}", data);
            return resulr.ToObject<ResponseBuilder<EventCreateResponse>>();
        }

        //public async Task<ResponseBuilder<DeleteTodoResponse>> DeleteTodoAsync(Guid id)
        //{
        //    var resulr = await DeleteAsync(@$"http://localhost:5000/{TodoEndpoint.V1.Todo.Delete.Path}/{id}");
        //    return resulr.ToObject<ResponseBuilder<DeleteTodoResponse>>();
        //}




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
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Add("Accept-Language", "id-ID");
                request.Content = httpContent;

                var response = await _client.SendAsync(request);
                //var response = await _client.PostAsync(url, httpContent);
                var content = await response.Content.ReadAsStringAsync();

                var contentObject = content.ToObject<ResponseBuilder<EventCreateResponse>>();

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
