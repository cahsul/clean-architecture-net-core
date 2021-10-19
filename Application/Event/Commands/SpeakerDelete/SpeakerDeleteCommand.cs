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
using Shared.Event.Commands.SpeakerDelete;
using Shared.X.Responses;

namespace Application.Event.Commands.SpeakerDelete
{

    public class SpeakerDeleteCommand : SpeakerDeleteRequest, IRequest<ResponseBuilder<SpeakerDeleteResponse>>
    {
    }

    public class Handler : IRequestHandler<SpeakerDeleteCommand, ResponseBuilder<SpeakerDeleteResponse>>
    {
        private readonly ISertiDbContext _sertiDbContext;

        public Handler(ISertiDbContext sertiDbContext)
        {
            _sertiDbContext = sertiDbContext;
        }

        public async Task<ResponseBuilder<SpeakerDeleteResponse>> Handle(SpeakerDeleteCommand request, CancellationToken cancellationToken)
        {
            var dataToDelete = new EventSpeaker
            {
                Id = request.Id,
            };

            _sertiDbContext.EventSpeakers.Attach(dataToDelete);
            _sertiDbContext.EventSpeakers.Remove(dataToDelete);
            await _sertiDbContext.SaveChangesAsync(cancellationToken);


            return new SpeakerDeleteResponse
            {
                Id = dataToDelete.Id,
            }.ResponseDelete();
        }
    }
}
