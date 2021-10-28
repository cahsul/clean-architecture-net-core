using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.X.Extensions;
using Application.X.Interfaces.Persistence;
using MediatR;
using Shared.Participant.Commands.CreateParticipant;
using Shared.X.Responses;

namespace Application.Participant.Commands.CreateParticipant
{
    public class CreateParticipantCommand : CreateParticipantRequest, IRequest<ResponseBuilder<CreateParticipantResponse>>
    {
    }

    public class Handler : IRequestHandler<CreateParticipantCommand, ResponseBuilder<CreateParticipantResponse>>
    {
        private readonly ISertiDbContext _sertiDbContext;

        public Handler(ISertiDbContext sertiDbContext)
        {
            _sertiDbContext = sertiDbContext;
        }

        public async Task<ResponseBuilder<CreateParticipantResponse>> Handle(CreateParticipantCommand request, CancellationToken cancellationToken)
        {
            // save
            var dataToSave = new Domain.Entities.Serti.Participant
            {
                ParticipantName = "ParticipantName",
                EventId = null,
                CertificateTemplateId = null,
                OwnerId = null,
            };

            _sertiDbContext.Participants.Add(dataToSave);
            await _sertiDbContext.SaveChangesAsync();


            return new CreateParticipantResponse
            {
                Id = dataToSave.Id,
            }.ResponseCreate();
        }
    }
}
