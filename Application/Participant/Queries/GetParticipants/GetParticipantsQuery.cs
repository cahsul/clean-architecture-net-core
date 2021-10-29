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
using Shared.Participant.Queries.GetParticipants;
using Shared.X.Responses;

namespace Application.Participant.Queries.GetParticipants
{
    public class GetParticipantsQuery : GetParticipantsRequest, IRequest<ResponseBuilder<List<GetParticipantsResponse>>>
    {

    }

    public class Handler : IRequestHandler<GetParticipantsQuery, ResponseBuilder<List<GetParticipantsResponse>>>
    {
        private readonly ISertiDbContext _sertiDbContext;

        public Handler(ISertiDbContext sertiDbContext)
        {
            _sertiDbContext = sertiDbContext;
        }

        public async Task<ResponseBuilder<List<GetParticipantsResponse>>> Handle(GetParticipantsQuery request, CancellationToken cancellationToken)
        {
            var data = await _sertiDbContext.Participants
                .OrderByDescending(o => o.CreatedDate)
                .Select(s => new GetParticipantsResponse
                {
                    Id = s.Id,
                    CertificateTemplateId = s.CertificateTemplateId,
                    EventId = s.EventId,
                    OwnerId = s.OwnerId,
                    ParticipantName = s.ParticipantName,
                })
                .ToListAsync(cancellationToken);

            return data.Response();
        }
    }
}
