using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.X.Extensions;
using Application.X.Interfaces.Persistence;
using MediatR;
using Shared.Participant.Commands.DeleteParticipant;
using Shared.X.Responses;

namespace Application.Participant.Commands.DeleteParticipant
{

    public class DeleteParticipantCommand : DeleteParticipantRequest, IRequest<ResponseBuilder<DeleteParticipantResponse>>
    {
    }

    public class Handler : IRequestHandler<DeleteParticipantCommand, ResponseBuilder<DeleteParticipantResponse>>
    {
        private readonly ISertiDbContext _sertiDbContext;

        public Handler(ISertiDbContext sertiDbContext)
        {
            _sertiDbContext = sertiDbContext;
        }

        public async Task<ResponseBuilder<DeleteParticipantResponse>> Handle(DeleteParticipantCommand request, CancellationToken cancellationToken)
        {
            var dataToDelete = new Domain.Entities.Serti.Participant
            {
                Id = request.Id,
            };

            _sertiDbContext.Participants.Remove(dataToDelete);
            await _sertiDbContext.SaveChangesAsync(cancellationToken);


            return new DeleteParticipantResponse
            {
                Id = dataToDelete.Id,
            }.ResponseDelete();
        }
    }
}
