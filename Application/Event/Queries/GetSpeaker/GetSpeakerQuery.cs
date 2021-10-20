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
using Shared.Event.Queries.GetSpeaker;
using Shared.X.Responses;

namespace Application.Event.Queries.GetSpeaker
{

    public class GetSpeakerQuery : GetSpeakerRequest, IRequest<ResponseBuilder<GetSpeakerResponse>>
    {

    }

    public class Handler : IRequestHandler<GetSpeakerQuery, ResponseBuilder<GetSpeakerResponse>>
    {
        private readonly ISertiDbContext _sertiDbContext;

        public Handler(ISertiDbContext sertiDbContext)
        {
            _sertiDbContext = sertiDbContext;
        }

        public async Task<ResponseBuilder<GetSpeakerResponse>> Handle(GetSpeakerQuery request, CancellationToken cancellationToken)
        {
            var data = await _sertiDbContext.EventSpeakers
                .Where(w => w.Id == request.Id)
                .Select(s => new GetSpeakerResponse
                {
                    Id = s.Id,
                    EventId = s.EventId,
                    Institution = s.Institution,
                    SpeakerName = s.SpeakerName,
                    Topics = s.Topics,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return data.Response();
        }
    }
}
