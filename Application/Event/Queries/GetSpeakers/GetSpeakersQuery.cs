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
using Shared.Event.Queries.GetSpeakers;
using Shared.X.Responses;

namespace Application.Event.Queries.GetSpeakers
{
    public class GetSpeakersQuery : GetSpeakersRequest, IRequest<ResponseBuilder<List<GetSpeakersResponse>>>
    {

    }

    public class Handler : IRequestHandler<GetSpeakersQuery, ResponseBuilder<List<GetSpeakersResponse>>>
    {
        private readonly ISertiDbContext _sertiDbContext;

        public Handler(ISertiDbContext sertiDbContext)
        {
            _sertiDbContext = sertiDbContext;
        }

        public async Task<ResponseBuilder<List<GetSpeakersResponse>>> Handle(GetSpeakersQuery request, CancellationToken cancellationToken)
        {
            var data = await _sertiDbContext.EventSpeakers
                .Select(s => new GetSpeakersResponse
                {
                    Id = s.Id,
                    EventId = s.EventId,
                    Institution = s.Institution,
                    SpeakerName = s.SpeakerName,
                    Topics = s.Topics,
                })
                .ToListAsync(cancellationToken)
                ;

            return data.Response();
        }
    }

}
