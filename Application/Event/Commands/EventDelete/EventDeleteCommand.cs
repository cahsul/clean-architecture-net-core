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
using Shared.Event.Commands.EventDelete;
using Shared.X.Responses;

namespace Application.Event.Commands.EventDelete
{

    public class EventDeleteCommand : EventDeleteRequest, IRequest<ResponseBuilder<EventDeleteResponse>>
    {
    }

    public class Handler : IRequestHandler<EventDeleteCommand, ResponseBuilder<EventDeleteResponse>>
    {
        private readonly ISertiDbContext _sertiDbContext;

        public Handler(ISertiDbContext sertiDbContext)
        {
            _sertiDbContext = sertiDbContext;
        }

        public async Task<ResponseBuilder<EventDeleteResponse>> Handle(EventDeleteCommand request, CancellationToken cancellationToken)
        {
            var dataToDelete = new Domain.Entities.Serti.Event
            {
                Id = request.Id,
            };

            _sertiDbContext.Events.Attach(dataToDelete);
            _sertiDbContext.Events.Remove(dataToDelete);
            await _sertiDbContext.SaveChangesAsync(cancellationToken);


            return new EventDeleteResponse
            {
                Id = dataToDelete.Id,
            }.ResponseDelete();
        }
    }
}
