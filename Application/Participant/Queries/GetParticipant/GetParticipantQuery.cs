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
using Shared.Participant.Queries.GetParticipant;
using Shared.X.Responses;

namespace Application.Participant.Queries.GetParticipant
{
    public class GetParticipantQuery : GetParticipantRequest, IRequest<ResponseBuilder<GetParticipantResponse>>
    {

    }

    public class Handler : IRequestHandler<GetParticipantQuery, ResponseBuilder<GetParticipantResponse>>
    {
        private readonly ISertiDbContext _sertiDbContext;

        public Handler(ISertiDbContext sertiDbContext)
        {
            _sertiDbContext = sertiDbContext;
        }

        public async Task<ResponseBuilder<GetParticipantResponse>> Handle(GetParticipantQuery request, CancellationToken cancellationToken)
        {
            var data = await _sertiDbContext.Participants
                .Where(w => w.Id == request.Id)
                .Select(s => new GetParticipantResponse
                {
                    Id = s.Id,
                    ParticipantName = s.ParticipantName,
                    OwnerId = s.OwnerId,
                    EventId = s.EventId,
                    CertificateTemplateId = s.CertificateTemplateId
                })
                .FirstOrDefaultAsync(cancellationToken);

            return data.Response();
        }
    }
}
