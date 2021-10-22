using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.X.Extensions;
using Application.X.Interfaces.Persistence;
using Application.X.Interfaces.UploadFile;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Event.Commands.UpdateEvent;
using Shared.Event.Enums;
using Shared.X.Extensions;
using Shared.X.Responses;

namespace Application.Event.Commands.UpdateEvent
{
    public class UpdateEventCommand : UpdateEventRequest, IRequest<ResponseBuilder<UpdateEventResponse>>
    {
    }

    public class Handler : IRequestHandler<UpdateEventCommand, ResponseBuilder<UpdateEventResponse>>
    {
        private readonly ISertiDbContext _sertiDbContext;
        private readonly IUploadFile _uploadFile;

        public Handler(ISertiDbContext sertiDbContext, IUploadFile uploadFile)
        {
            _sertiDbContext = sertiDbContext;
            _uploadFile = uploadFile;
        }

        public async Task<ResponseBuilder<UpdateEventResponse>> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            // find data
            var dataToUpdate = await _sertiDbContext.Events.FirstOrDefaultAsync(w => w.Id == request.Id);
            dataToUpdate.EventName = request.EventName;
            dataToUpdate.EventStatus = StatusEvent.Submit.GetDescription();

            var fileName = _uploadFile.ToFolder(request.Poster);
            dataToUpdate.Poster = fileName;

            _sertiDbContext.Events.Update(dataToUpdate);
            await _sertiDbContext.SaveChangesAsync(cancellationToken);


            return new UpdateEventResponse
            {
                Id = dataToUpdate.Id,
            }.ResponseUpdate();
        }
    }
}
