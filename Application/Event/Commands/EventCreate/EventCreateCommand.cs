using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shared.X.Responses;
using Shared.Event.Commands.EventCreate;
using Serti = Domain.Entities.Serti;
using Application.X.Extensions;
using Application.X.Interfaces.Persistence;

namespace Application.Event.Commands.EventCreate
{
    public class EventCreateCommand : EventCreateRequest, IRequest<ResponseBuilder<EventCreateResponse>>
    {
    }

    public class Handler : IRequestHandler<EventCreateCommand, ResponseBuilder<EventCreateResponse>>
    {
        private readonly ISertiDbContext _sertiDbContext;

        public Handler(ISertiDbContext sertiDbContext)
        {
            _sertiDbContext = sertiDbContext;
        }

        public async Task<ResponseBuilder<EventCreateResponse>> Handle(EventCreateCommand request, CancellationToken cancellationToken)
        {
            // save
            var dataToSave = new Serti.Event
            {
                EventName = request.EventName.Trim(),
            };

            await _sertiDbContext.Events.AddAsync(dataToSave);
            await _sertiDbContext.SaveChangesAsync();


            return new EventCreateResponse
            {
                Id = dataToSave.Id,
            }.ResponseCreate();
        }
    }
}
