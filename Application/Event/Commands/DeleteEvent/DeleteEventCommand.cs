using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.X.Extensions;
using Application.X.Interfaces.Persistence;
using Domain.Entities.Serti;
using MediatR;
using Shared.Event.Commands.DeleteEvent;
using Shared.X.Responses;

namespace Application.Event.Commands.DeleteEvent
{

    public class DeleteEventCommand : DeleteEventRequest, IRequest<ResponseBuilder<DeleteEventResponse>>
    {
    }

    public class Handler : IRequestHandler<DeleteEventCommand, ResponseBuilder<DeleteEventResponse>>
    {
        private readonly ISertiDbContext _sertiDbContext;

        public Handler(ISertiDbContext sertiDbContext)
        {
            _sertiDbContext = sertiDbContext;
        }

        public async Task<ResponseBuilder<DeleteEventResponse>> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var dataToDelete = new Domain.Entities.Serti.Event
            {
                Id = request.Id,
            };

            _sertiDbContext.Events.Attach(dataToDelete);
            _sertiDbContext.Events.Remove(dataToDelete);
            await _sertiDbContext.SaveChangesAsync(cancellationToken);


            return new DeleteEventResponse
            {
                Id = dataToDelete.Id,
            }.ResponseDelete();
        }
    }
}
