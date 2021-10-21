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
using Shared.Event.Commands.UpdateEvent;
using Shared.X.Responses;

namespace Application.Event.Commands.UpdateEvent
{
    public class UpdateEventCommand : UpdateEventRequest, IRequest<ResponseBuilder<UpdateEventResponse>>
    {
    }

    public class Handler : IRequestHandler<UpdateEventCommand, ResponseBuilder<UpdateEventResponse>>
    {
        private readonly ISertiDbContext _sertiDbContext;

        public Handler(ISertiDbContext sertiDbContext)
        {
            _sertiDbContext = sertiDbContext;
        }

        public async Task<ResponseBuilder<UpdateEventResponse>> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            // find data
            var dataToUpdate = await _sertiDbContext.Events.FirstOrDefaultAsync(w => w.Id == request.Id);
            dataToUpdate.EventName = request.EventName;

            _sertiDbContext.Events.Update(dataToUpdate);
            await _sertiDbContext.SaveChangesAsync(cancellationToken);


            return new UpdateEventResponse
            {
                Id = dataToUpdate.Id,
            }.ResponseUpdate();
        }
    }
}
