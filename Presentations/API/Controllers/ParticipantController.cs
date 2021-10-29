using Application.Participant.Commands.CreateParticipant;
using Application.Participant.Commands.DeleteParticipant;
using Application.Participant.Commands.UpdateParticipant;
using Application.Participant.Queries.GetParticipant;
using Application.Participant.Queries.GetParticipants;
using Microsoft.AspNetCore.Mvc;
using Shared.Participant.Commands.CreateParticipant;
using Shared.Participant.Commands.DeleteParticipant;
using Shared.Participant.Commands.UpdateParticipant;
using Shared.Participant.Queries.GetParticipant;
using Shared.Participant.Queries.GetParticipants;
using Shared.X.Responses;

namespace API.Controllers
{

    public class ParticipantController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<ResponseBuilder<List<GetParticipantsResponse>>>> GetParticipants(GetParticipantsQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{Id:guid}")]
        public async Task<ActionResult<ResponseBuilder<GetParticipantResponse>>> GetParticipant([FromRoute] GetParticipantQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpPost()]
        public async Task<ActionResult<ResponseBuilder<CreateParticipantResponse>>> EventCreate([FromBody] CreateParticipantCommand query)
        {
            return await Mediator.Send(query);
        }

        [HttpDelete("{Id:guid}")]
        public async Task<ActionResult<ResponseBuilder<DeleteParticipantResponse>>> EventDelete([FromRoute] DeleteParticipantCommand query)
        {
            return await Mediator.Send(query);
        }

        [HttpPut()]
        public async Task<ActionResult<ResponseBuilder<UpdateParticipantResponse>>> EventUpdate([FromBody] UpdateParticipantCommand query)
        {
            return await Mediator.Send(query);
        }
    }
}
