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
using Shared.Event.Commands.SpeakerCreate;
using Shared.X.Responses;

namespace Application.Event.Commands.SpeakerCreate
{
    public class SpeakerCreateCommand : SpeakerCreateRequest, IRequest<ResponseBuilder<SpeakerCreateResponse>>
    {
    }

    public class Handler : IRequestHandler<SpeakerCreateCommand, ResponseBuilder<SpeakerCreateResponse>>
    {
        private readonly ISertiDbContext _sertiDbContext;

        public Handler(ISertiDbContext sertiDbContext)
        {
            _sertiDbContext = sertiDbContext;
        }

        public async Task<ResponseBuilder<SpeakerCreateResponse>> Handle(SpeakerCreateCommand request, CancellationToken cancellationToken)
        {
            var dataToSave = new EventSpeaker
            {
                EventId = request.EventId,
                SpeakerName = request.SpeakerName,
                Topics = request.Topics,
                Institution = request.Institution,
            };

            await _sertiDbContext.EventSpeakers.AddAsync(dataToSave);
            await _sertiDbContext.SaveChangesAsync(cancellationToken);


            return new SpeakerCreateResponse
            {
                Id = dataToSave.Id,
            }.ResponseCreate();
        }
    }
}
