using Microsoft.AspNetCore.Mvc;
using Shared.X.Responses;
using Shared.Event.Resources;
using System.Threading.Tasks;
using Application.Event.Queries.GetSpeakers;
using Shared.Event.Queries.GetSpeakers;
using Application.Event.Queries.GetEvents;
using Shared.Event.Queries.GetEvents;
using Application.Event.Queries.GetEvent;
using Shared.Event.Queries.GetEvent;
using Shared.Event.Queries.GetSpeaker;
using Application.Event.Queries.GetSpeaker;
using Application.Event.Queries.GetSpeakersByEvent;
using Shared.Event.Queries.GetSpeakersByEvent;
using Shared.Event.Commands.UpdateEvent;
using Shared.Event.Commands.DeleteEvent;
using Shared.Event.Commands.UpdateSpeaker;
using Shared.Event.Commands.DeleteSpeaker;
using Shared.Event.Commands.CreateEvent;
using Shared.Event.Commands.CreateSpeaker;
using Application.Event.Commands.CreateSpeaker;
using Application.Event.Commands.UpdateEvent;
using Application.Event.Commands.DeleteEvent;
using Application.Event.Commands.UpdateSpeaker;
using Application.Event.Commands.DeleteSpeaker;
using Application.Event.Commands.CreateEvent;

namespace API.Controllers
{
    /// <summary>
    /// pembuatan event
    /// </summary>
    [ApiVersion("1")]
    public class EventController : ApiController
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
        public async Task<ActionResult<ResponseBuilder<CreateEventResponse>>> EventCreate([FromBody] CreateEventCommand query)
        {
            return await Mediator.Send(query);
        }

        [HttpDelete(EventEndpoint.Event.Delete)]
        public async Task<ActionResult<ResponseBuilder<DeleteEventResponse>>> EventDelete([FromBody] DeleteEventCommand query)
        {
            return await Mediator.Send(query);
        }

        [HttpPut(EventEndpoint.Event.Update)]
        public async Task<ActionResult<ResponseBuilder<UpdateEventResponse>>> EventUpdate([FromForm] UpdateEventCommand query)
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
        public async Task<ActionResult<ResponseBuilder<CreateSpeakerResponse>>> SpeakerCreate([FromBody] CreateSpeakerCommand query)
        {
            return await Mediator.Send(query);
        }

        [HttpDelete(EventEndpoint.EventSpeaker.Delete)]
        public async Task<ActionResult<ResponseBuilder<DeleteSpeakerResponse>>> SpeakerDelete([FromBody] DeleteSpeakerCommand query)
        {
            return await Mediator.Send(query);
        }

        [HttpPut(EventEndpoint.EventSpeaker.Update)]
        public async Task<ActionResult<ResponseBuilder<UpdateSpeakerResponse>>> SpeakerUpdate([FromBody] UpdateSpeakerCommand query)
        {
            return await Mediator.Send(query);
        }

        #endregion Speaker
    }
}
