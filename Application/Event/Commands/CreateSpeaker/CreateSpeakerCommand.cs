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
using Shared.Event.Commands.CreateSpeaker;
using Shared.X.Responses;

namespace Application.Event.Commands.CreateSpeaker
{
    public class CreateSpeakerCommand : CreateSpeakerRequest, IRequest<ResponseBuilder<CreateSpeakerResponse>>
    {
    }

    public class Handler : IRequestHandler<CreateSpeakerCommand, ResponseBuilder<CreateSpeakerResponse>>
    {
        private readonly ISertiDbContext _sertiDbContext;

        public Handler(ISertiDbContext sertiDbContext)
        {
            _sertiDbContext = sertiDbContext;
        }

        public async Task<ResponseBuilder<CreateSpeakerResponse>> Handle(CreateSpeakerCommand request, CancellationToken cancellationToken)
        {
            var dataToSave = new EventSpeaker
            {
                Id = (Guid)request.Id,
                EventId = request.EventId,
                SpeakerName = request.SpeakerName,
                Topics = request.Topics,
                Institution = request.Institution,
            };

            await _sertiDbContext.EventSpeakers.AddAsync(dataToSave);
            await _sertiDbContext.SaveChangesAsync(cancellationToken);


            return new CreateSpeakerResponse
            {
                Id = dataToSave.Id,
            }.ResponseCreate();
        }
    }
}
