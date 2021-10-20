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
using Shared.Event.Queries.GetSpeakersByEvent;
using Shared.X.Responses;

namespace Application.Event.Queries.GetSpeakersByEvent
{
    public class GetSpeakersByEventQuery : GetSpeakersByEventRequest, IRequest<ResponseBuilder<List<GetSpeakersByEventResponse>>>
    {

    }

    public class Handler : IRequestHandler<GetSpeakersByEventQuery, ResponseBuilder<List<GetSpeakersByEventResponse>>>
    {
        private readonly ISertiDbContext _sertiDbContext;

        public Handler(ISertiDbContext sertiDbContext)
        {
            _sertiDbContext = sertiDbContext;
        }

        public async Task<ResponseBuilder<List<GetSpeakersByEventResponse>>> Handle(GetSpeakersByEventQuery request, CancellationToken cancellationToken)
        {
            var data = await _sertiDbContext.EventSpeakers
                .Where(w => w.EventId == request.EventId)
                .Select(s => new GetSpeakersByEventResponse
                {
                    Id = s.Id,
                    EventId = s.EventId,
                    Institution = s.Institution,
                    SpeakerName = s.SpeakerName,
                    Topics = s.Topics,
                })
                .ToListAsync(cancellationToken);

            return data.Response();
        }
    }
}
