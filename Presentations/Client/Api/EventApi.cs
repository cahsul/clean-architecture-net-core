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
using Shared.Event.Queries.GetEvents;
using Shared.Event.Commands.EventDelete;
using Shared.Event.Commands.SpeakerCreate;
using Shared.Event.Commands.SpeakerDelete;
using Shared.Event.Queries.GetEvent;
using Shared.Event.Queries.GetSpeaker;
using Shared.Event.Queries.GetSpeakers;
using Shared.Event.Commands.SpeakerUpdate;
using Shared.Event.Queries.GetSpeakersByEvent;
using Shared.Event.Commands.EventUpdate;

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

        public async Task<ResponseBuilder<EventCreateResponse>> EventCreateAsync(EventCreateRequest request)
        {
            var result = await request.PostAsync<EventCreateResponse>($"{_appsettings.Api_Serti()}{EventEndpoint.Event.Create}");
            return result;
        }

        public async Task<ResponseBuilder<EventUpdateResponse>> EventUpdateAsync(EventUpdateRequest request)
        {
            var result = await request.PutAsync<EventUpdateResponse>($"{_appsettings.Api_Serti()}{EventEndpoint.Event.Update}");
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

        public async Task<ResponseBuilder<EventDeleteResponse>> EventDeleteAsync(EventDeleteRequest request)
        {
            var result = await request.DeleteAsync<EventDeleteResponse>($"{_appsettings.Api_Serti()}{EventEndpoint.Event.Delete}");
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

        public async Task<ResponseBuilder<SpeakerCreateResponse>> SpeakerCreateAsync(SpeakerCreateRequest request)
        {
            var result = await request.PostAsync<SpeakerCreateResponse>($"{_appsettings.Api_Serti()}{EventEndpoint.EventSpeaker.Create}");
            return result;
        }

        public async Task<ResponseBuilder<SpeakerUpdateResponse>> SpeakerUpdateAsync(SpeakerUpdateRequest request)
        {
            var result = await request.PutAsync<SpeakerUpdateResponse>($"{_appsettings.Api_Serti()}{EventEndpoint.EventSpeaker.Update}");
            return result;
        }

        public async Task<ResponseBuilder<EventDeleteResponse>> SpeakerDeleteAsync(SpeakerDeleteRequest request)
        {
            var result = await request.DeleteAsync<EventDeleteResponse>($"{_appsettings.Api_Serti()}{EventEndpoint.EventSpeaker.Delete}");
            return result;
        }

        #endregion Speaker
    }
}
