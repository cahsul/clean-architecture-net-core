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
using Shared.Event.Queries.GetEvents;
using Shared.Event.Queries.GetEvent;
using Shared.Event.Queries.GetSpeaker;
using Shared.Event.Queries.GetSpeakers;
using Shared.Event.Queries.GetSpeakersByEvent;
using Shared.Event.Commands.UpdateEvent;
using Shared.Event.Commands.DeleteEvent;
using Shared.Event.Commands.UpdateSpeaker;
using Shared.Event.Commands.CreateEvent;
using Shared.Event.Commands.CreateSpeaker;
using Shared.Event.Commands.DeleteSpeaker;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Headers;
using System.Reflection;
using Serti.Client.X.Extensions;

namespace Serti.Client.Api
{
    public class EventApi
    {

        private readonly HttpClient _client;
        private readonly Appsettings _appsettings;
        private readonly NavigationManager _navigationManager;
        private readonly ToastrService _toastrService;

        public EventApi(ToastrService toastrService, HttpClient client, Appsettings appsettings, NavigationManager navigationManager)
        {

            _toastrService = toastrService;
            _client = client;
            _appsettings = appsettings;
            _navigationManager = navigationManager;
            HttpExtension.HttpExtensionConfigure(_toastrService, _client, _appsettings, _navigationManager);
        }

        public async Task<ResponseBuilder<CreateEventResponse>> EventCreateAsync(CreateEventRequest request)
        {
            var result = await request.PostAsync<CreateEventResponse>($"{_appsettings.Api_Serti()}{EventEndpoint.Event.Create}");
            return result;
        }

        public async Task<ResponseBuilder<UpdateEventResponse>> EventUpdateAsync(UpdateEventRequest request, List<IBrowserFile> files)
        {
            using var content = new MultipartFormDataContent();

            // colect files to contenct 
            foreach (var file in files)
            {
                var fileContent = new StreamContent(file.OpenReadStream());
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

                content.Add(
                   content: fileContent,
                   name: "\"Poster\"",
                   fileName: file.Name);
            }

            foreach (var prop in request.GetType().GetProperties())
            {
                if (prop.GetValue(request, null) != null)
                {
                    content.Add(new StringContent(prop.GetValue(request).ToString()), prop.Name);
                }
            }



            var result = await request.PutWithFile<UpdateEventResponse>($"{_appsettings.Api_Serti()}{EventEndpoint.Event.Update}", content);
            return result;
        }

        public async Task<ResponseBuilder<List<GetEventsResponse>>> EventsGetAsync(GetEventsRequest request)
        {
            var result = await request.GetAsync<List<GetEventsResponse>>($"{_appsettings.Api_Serti()}{EventEndpoint.Event.GetEvents}");
            return result;
        }

        public async Task<ResponseBuilder<GetEventResponse>> EventGetAsync(GetEventRequest request)
        {
            var result = await request.GetAsync<GetEventResponse>($"{_appsettings.Api_Serti()}{EventEndpoint.Event.GetEvent}/?Id={request.Id}");
            return result;
        }

        public async Task<ResponseBuilder<DeleteEventResponse>> EventDeleteAsync(DeleteEventRequest request)
        {
            var result = await request.DeleteAsync<DeleteEventResponse>($"{_appsettings.Api_Serti()}{EventEndpoint.Event.Delete}");
            return result;
        }


        #region Speaker

        public async Task<ResponseBuilder<GetSpeakerResponse>> SpeakerGetAsync(GetSpeakerRequest request)
        {
            var result = await request.GetAsync<GetSpeakerResponse>($"{_appsettings.Api_Serti()}{EventEndpoint.EventSpeaker.GetSpeaker}");
            return result;
        }

        public async Task<ResponseBuilder<List<GetSpeakerResponse>>> SpeakersGetAsync(GetSpeakersRequest request)
        {
            var result = await request.GetAsync<List<GetSpeakerResponse>>($"{_appsettings.Api_Serti()}{EventEndpoint.EventSpeaker.GetSpeakers}");
            return result;
        }

        public async Task<ResponseBuilder<List<GetSpeakersByEventResponse>>> GetSpeakersByEvent(GetSpeakersByEventRequest request)
        {
            var result = await request.GetAsync<List<GetSpeakersByEventResponse>>($"{_appsettings.Api_Serti()}{EventEndpoint.EventSpeaker.GetSpeakersByEvent}/?EventId={request.EventId}");
            return result;
        }

        public async Task<ResponseBuilder<CreateSpeakerResponse>> SpeakerCreateAsync(CreateSpeakerRequest request)
        {
            var result = await request.PostAsync<CreateSpeakerResponse>($"{_appsettings.Api_Serti()}{EventEndpoint.EventSpeaker.Create}");
            return result;
        }

        public async Task<ResponseBuilder<UpdateSpeakerResponse>> SpeakerUpdateAsync(UpdateSpeakerRequest request)
        {
            var result = await request.PutAsync<UpdateSpeakerResponse>($"{_appsettings.Api_Serti()}{EventEndpoint.EventSpeaker.Update}");
            return result;
        }

        public async Task<ResponseBuilder<DeleteEventResponse>> SpeakerDeleteAsync(DeleteSpeakerRequest request)
        {
            var result = await request.DeleteAsync<DeleteEventResponse>($"{_appsettings.Api_Serti()}{EventEndpoint.EventSpeaker.Delete}");
            return result;
        }

        #endregion Speaker
    }
}
