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
using Shared.Event.Queries.GetEvent;
using Shared.X.Responses;

namespace Application.Event.Queries.GetEvent
{
    public class GetEventQuery : GetEventRequest, IRequest<ResponseBuilder<GetEventResponse>>
    {

    }

    public class Handler : IRequestHandler<GetEventQuery, ResponseBuilder<GetEventResponse>>
    {
        private readonly ISertiDbContext _sertiDbContext;

        public Handler(ISertiDbContext sertiDbContext)
        {
            _sertiDbContext = sertiDbContext;
        }

        public async Task<ResponseBuilder<GetEventResponse>> Handle(GetEventQuery request, CancellationToken cancellationToken)
        {
            var data = await _sertiDbContext.Events
                .Where(w => w.Id == request.Id)
                .Select(s => new GetEventResponse
                {
                    Id = s.Id,
                    EventName = s.EventName,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return data.Response();
        }
    }
}
