using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Shared.X.Responses;
using Serti = Domain.Entities.Serti;
using Application.X.Extensions;
using Application.X.Interfaces.Persistence;
using Shared.Event.Commands.CreateEvent;
using Shared.Event.Enums;
using Shared.X.Extensions;

namespace Application.Event.Commands.CreateEvent
{
    public class CreateEventCommand : CreateEventRequest, IRequest<ResponseBuilder<CreateEventResponse>>
    {
    }

    public class Handler : IRequestHandler<CreateEventCommand, ResponseBuilder<CreateEventResponse>>
    {
        private readonly ISertiDbContext _sertiDbContext;

        public Handler(ISertiDbContext sertiDbContext)
        {
            _sertiDbContext = sertiDbContext;
        }

        public async Task<ResponseBuilder<CreateEventResponse>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            // save
            var dataToSave = new Serti.Event
            {
                EventName = request?.EventName?.Trim(),
                EventStatus = StatusEvent.Draft.GetDescription(),
            };

            await _sertiDbContext.Events.AddAsync(dataToSave);
            await _sertiDbContext.SaveChangesAsync();


            return new CreateEventResponse
            {
                Id = dataToSave.Id,
            }.ResponseCreate();
        }
    }
}
