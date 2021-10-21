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
using Shared.Event.Commands.DeleteSpeaker;
using Shared.X.Responses;

namespace Application.Event.Commands.DeleteSpeaker
{

    public class DeleteSpeakerCommand : DeleteSpeakerRequest, IRequest<ResponseBuilder<DeleteSpeakerResponse>>
    {
    }

    public class Handler : IRequestHandler<DeleteSpeakerCommand, ResponseBuilder<DeleteSpeakerResponse>>
    {
        private readonly ISertiDbContext _sertiDbContext;

        public Handler(ISertiDbContext sertiDbContext)
        {
            _sertiDbContext = sertiDbContext;
        }

        public async Task<ResponseBuilder<DeleteSpeakerResponse>> Handle(DeleteSpeakerCommand request, CancellationToken cancellationToken)
        {
            var dataToDelete = new EventSpeaker
            {
                Id = request.Id,
            };

            _sertiDbContext.EventSpeakers.Remove(dataToDelete);
            await _sertiDbContext.SaveChangesAsync(cancellationToken);


            return new DeleteSpeakerResponse
            {
                Id = dataToDelete.Id,
            }.ResponseDelete();
        }
    }
}
