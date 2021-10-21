﻿using System;
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

        public async Task<ResponseBuilder<CreateEventResponse>> EventCreateAsync(CreateEventRequest request)
        {
            var result = await request.PostAsync<CreateEventResponse>($"{_appsettings.Api_Serti()}{EventEndpoint.Event.Create}");
            return result;
        }

        public async Task<ResponseBuilder<UpdateEventResponse>> EventUpdateAsync(UpdateEventRequest request)
        {
            var result = await request.PutAsync<UpdateEventResponse>($"{_appsettings.Api_Serti()}{EventEndpoint.Event.Update}");
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
