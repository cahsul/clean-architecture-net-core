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
using Shared.Participant.Queries.GetEvents;
using Shared.X.Responses;

namespace Application.Participant.Queries.GetEvents
{
    public class GetEventsQuery : GetEventsReqeust, IRequest<ResponseBuilder<List<GetEventsResponse>>>
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
            //var dataz = await _sertiDbContext.Events
            //    .OrderByDescending(o => o.CreatedDate)
            //    .Select(s => new GetEventsForParticipantResponse
            //    {
            //        Id = s.Id,
            //        EventName = s.EventName,
            //        TotalParticipant = 9999
            //    })
            //    .ToListAsync(cancellationToken);

            var dataz = await (
                    from e in _sertiDbContext.Events
                    group e by e.Id into g
                    join p in _sertiDbContext.Participants on g.FirstOrDefault().Id equals p.Id //into tmpP
                    //from p in tmpP.DefaultIfEmpty()
                    select new GetEventsResponse
                    {
                        Id = g.FirstOrDefault().Id,
                        EventName = g.FirstOrDefault().EventName,
                        TotalParticipant = g.Count(),
                    }
                ).ToListAsync();

            var data = await (
                    from e in _sertiDbContext.Events
                    from p in _sertiDbContext.Participants.Where(w => w.EventId == e.Id).DefaultIfEmpty()
                    group e by e.Id into g
                    select new GetEventsResponse
                    {
                        Id = g.FirstOrDefault().Id,
                        EventName = g.FirstOrDefault().EventName,
                        TotalParticipant = g.Count(),
                    }
                ).ToListAsync();

            return data.Response();
        }
    }
}
