using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.X.Attributes;
using Application.X.Extensions;
using Application.X.Interfaces.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Event.Queries.GetEvents;
using Shared.X.Responses;

namespace Application.Event.Queries.GetEvents
{
    [Authorize("Todo", "List")]
    public class GetEventsQuery : GetEventsRequest, IRequest<ResponseBuilder<List<GetEventsResponse>>>
    {

    }

    public class Handler : IRequestHandler<GetEventsQuery, ResponseBuilder<List<GetEventsResponse>>>
    {
        private readonly ISertiDbContext _sertiDbContext;

        public Handler(ISertiDbContext sertiDbContext)
        {
            _sertiDbContext = sertiDbContext;
        }

        public async Task<ResponseBuilder<List<GetEventsResponse>>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            var data = await _sertiDbContext.Events
                .OrderByDescending(o => o.CreatedDate)
                .Select(s => new GetEventsResponse
                {
                    Id = s.Id,
                    EventName = s.EventName,
                })
                .ToListAsync(cancellationToken);

            return data.Response();
        }
    }

}
