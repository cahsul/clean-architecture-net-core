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
using Shared.Event.Commands.EventUpdate;
using Shared.X.Responses;

namespace Application.Event.Commands.EventUpdate
{
    public class EventUpdateCommand : EventUpdateRequest, IRequest<ResponseBuilder<EventUpdateResponse>>
    {
    }

    public class Handler : IRequestHandler<EventUpdateCommand, ResponseBuilder<EventUpdateResponse>>
    {
        private readonly ISertiDbContext _sertiDbContext;

        public Handler(ISertiDbContext sertiDbContext)
        {
            _sertiDbContext = sertiDbContext;
        }

        public async Task<ResponseBuilder<EventUpdateResponse>> Handle(EventUpdateCommand request, CancellationToken cancellationToken)
        {
            // find data
            var dataToUpdate = await _sertiDbContext.Events.FirstOrDefaultAsync(w => w.Id == request.Id);
            dataToUpdate.EventName = request.EventName;

            _sertiDbContext.Events.Update(dataToUpdate);
            await _sertiDbContext.SaveChangesAsync(cancellationToken);


            return new EventUpdateResponse
            {
                Id = dataToUpdate.Id,
            }.ResponseUpdate();
        }
    }
}
