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
using Microsoft.EntityFrameworkCore;
using Shared.Event.Commands.SpeakerUpdate;
using Shared.X.Responses;

namespace Application.Event.Commands.SpeakerUpdate
{

    public class SpeakerUpdateCommand : SpeakerUpdateRequest, IRequest<ResponseBuilder<SpeakerUpdateResponse>>
    {
    }

    public class Handler : IRequestHandler<SpeakerUpdateCommand, ResponseBuilder<SpeakerUpdateResponse>>
    {
        private readonly ISertiDbContext _sertiDbContext;

        public Handler(ISertiDbContext sertiDbContext)
        {
            _sertiDbContext = sertiDbContext;
        }

        public async Task<ResponseBuilder<SpeakerUpdateResponse>> Handle(SpeakerUpdateCommand request, CancellationToken cancellationToken)
        {
            // find data
            var dataToUpdate = await _sertiDbContext.EventSpeakers.FirstOrDefaultAsync(w => w.Id == request.Id);
            dataToUpdate.SpeakerName = request.SpeakerName;
            dataToUpdate.Topics = request.Topics;
            dataToUpdate.Institution = request.Institution;

            _sertiDbContext.EventSpeakers.Update(dataToUpdate);
            await _sertiDbContext.SaveChangesAsync(cancellationToken);


            return new SpeakerUpdateResponse
            {
                Id = dataToUpdate.Id,
            }.ResponseUpdate();
        }
    }
}
