using Application.Participant.Commands.CreateParticipant;
using Application.Participant.Commands.DeleteParticipant;
using Application.Participant.Commands.UpdateParticipant;
using Microsoft.AspNetCore.Mvc;
using Shared.Participant.Commands.CreateParticipant;
using Shared.Participant.Commands.DeleteParticipant;
using Shared.Participant.Commands.UpdateParticipant;
using Shared.Participant.Resources;
using Shared.X.Responses;

namespace API.Controllers.V1
{

    public class ParticipantController : ApiV1Controller
    {
        [HttpPost(ParticipantEndpoint.Participant.Create)]
        public async Task<ActionResult<ResponseBuilder<CreateParticipantResponse>>> EventCreate([FromBody] CreateParticipantCommand query)
        {
            return await Mediator.Send(query);
        }

        [HttpDelete(ParticipantEndpoint.Participant.Delete)]
        public async Task<ActionResult<ResponseBuilder<DeleteParticipantResponse>>> EventDelete([FromBody] DeleteParticipantCommand query)
        {
            return await Mediator.Send(query);
        }

        [HttpPut(ParticipantEndpoint.Participant.Update)]
        public async Task<ActionResult<ResponseBuilder<UpdateParticipantResponse>>> EventUpdate([FromBody] UpdateParticipantCommand query)
        {
            return await Mediator.Send(query);
        }
    }
}
