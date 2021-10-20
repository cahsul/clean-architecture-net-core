﻿using Application.Event.Commands.EventCreate;
using Microsoft.AspNetCore.Mvc;
using Shared.X.Responses;
using Shared.Event.Commands.EventCreate;
using Shared.Event.Resources;
using System.Threading.Tasks;
using Application.Event.Commands.SpeakerCreate;
using Shared.Event.Commands.SpeakerCreate;
using Application.Event.Commands.SpeakerDelete;
using Shared.Event.Commands.SpeakerDelete;
using Shared.Event.Commands.SpeakerUpdate;
using Application.Event.Commands.SpeakerUpdate;
using Application.Event.Queries.GetSpeakers;
using Shared.Event.Queries.GetSpeakers;
using Application.Event.Queries.GetEvents;
using Shared.Event.Queries.GetEvents;
using Application.Event.Commands.EventUpdate;
using Shared.Event.Commands.EventUpdate;
using Application.Event.Commands.EventDelete;
using Shared.Event.Commands.EventDelete;
using Application.Event.Queries.GetEvent;
using Shared.Event.Queries.GetEvent;
using Shared.Event.Queries.GetSpeaker;
using Application.Event.Queries.GetSpeaker;
using Application.Event.Queries.GetSpeakersByEvent;
using Shared.Event.Queries.GetSpeakersByEvent;

namespace API.Controllers.V1
{
    /// <summary>
    /// pembuatan event
    /// </summary>
    [ApiVersion("1")]
    public class EventController : ApiV1Controller
    {

        #region Event

        [HttpGet(EventEndpoint.Event.GetEvent)]
        public async Task<ActionResult<ResponseBuilder<GetEventResponse>>> GetEvent(GetEventQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet(EventEndpoint.Event.GetEvents)]
        public async Task<ActionResult<ResponseBuilder<List<GetEventsResponse>>>> GetEvents(GetEventsQuery query)
        {
            //var ggg = User.Identity.AuthenticationType;
            return await Mediator.Send(query);
        }

        [HttpPost(EventEndpoint.Event.Create)]
        public async Task<ActionResult<ResponseBuilder<EventCreateResponse>>> EventCreate([FromBody] EventCreateCommand query)
        {
            return await Mediator.Send(query);
        }

        [HttpDelete(EventEndpoint.Event.Delete)]
        public async Task<ActionResult<ResponseBuilder<EventDeleteResponse>>> EventDelete([FromBody] EventDeleteCommand query)
        {
            return await Mediator.Send(query);
        }

        [HttpPut(EventEndpoint.Event.Update)]
        public async Task<ActionResult<ResponseBuilder<EventUpdateResponse>>> EventUpdate([FromBody] EventUpdateCommand query)
        {
            return await Mediator.Send(query);
        }

        #endregion Event



        #region Speaker

        [HttpGet(EventEndpoint.EventSpeaker.GetSpeaker)]
        public async Task<ActionResult<ResponseBuilder<GetSpeakerResponse>>> GetSpeaker(GetSpeakerQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet(EventEndpoint.EventSpeaker.GetSpeakers)]
        public async Task<ActionResult<ResponseBuilder<List<GetSpeakersResponse>>>> GetSpeakers(GetSpeakersQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet(EventEndpoint.EventSpeaker.GetSpeakersByEvent)]
        public async Task<ActionResult<ResponseBuilder<List<GetSpeakersByEventResponse>>>> GetSpeakersByEvent(GetSpeakersByEventQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost(EventEndpoint.EventSpeaker.Create)]
        public async Task<ActionResult<ResponseBuilder<SpeakerCreateResponse>>> SpeakerCreate([FromBody] SpeakerCreateCommand query)
        {
            return await Mediator.Send(query);
        }

        [HttpDelete(EventEndpoint.EventSpeaker.Delete)]
        public async Task<ActionResult<ResponseBuilder<SpeakerDeleteResponse>>> SpeakerDelete([FromBody] SpeakerDeleteCommand query)
        {
            return await Mediator.Send(query);
        }

        [HttpPut(EventEndpoint.EventSpeaker.Update)]
        public async Task<ActionResult<ResponseBuilder<SpeakerUpdateResponse>>> SpeakerUpdate([FromBody] SpeakerUpdateCommand query)
        {
            return await Mediator.Send(query);
        }

        #endregion Speaker
    }
}
