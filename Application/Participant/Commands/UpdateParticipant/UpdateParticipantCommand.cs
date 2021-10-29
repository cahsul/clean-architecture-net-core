using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.X.Extensions;
using Application.X.Interfaces.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Participant.Commands.UpdateParticipant;
using Shared.X.Responses;

namespace Application.Participant.Commands.UpdateParticipant
{
    public class UpdateParticipantCommand : UpdateParticipantRequest, IRequest<ResponseBuilder<UpdateParticipantResponse>>
    {
    }

    public class Handler : IRequestHandler<UpdateParticipantCommand, ResponseBuilder<UpdateParticipantResponse>>
    {
        private readonly ISertiDbContext _sertiDbContext;

        public Handler(ISertiDbContext sertiDbContext)
        {
            _sertiDbContext = sertiDbContext;
        }

        public async Task<ResponseBuilder<UpdateParticipantResponse>> Handle(UpdateParticipantCommand request, CancellationToken cancellationToken)
        {
            // find data
            var dataToUpdate = await _sertiDbContext.Participants.FirstOrDefaultAsync(w => w.Id == request.Id);
            dataToUpdate.ParticipantName = request.ParticipantName;
            dataToUpdate.CertificateTemplateId = request.CertificateTemplateId;

            _sertiDbContext.Participants.Update(dataToUpdate);
            await _sertiDbContext.SaveChangesAsync(cancellationToken);


            return new UpdateParticipantResponse
            {
                Id = dataToUpdate.Id,
            }.ResponseUpdate();
        }
    }
}
