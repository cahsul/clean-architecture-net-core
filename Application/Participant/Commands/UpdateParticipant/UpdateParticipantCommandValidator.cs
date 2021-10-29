using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.X.Interfaces.Persistence;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shared.Participant.Commands.UpdateParticipant;
using Shared.X.Resources;

namespace Application.Participant.Commands.UpdateParticipant
{
    public class UpdateParticipantCommandValidator : AbstractValidator<UpdateParticipantCommand>
    {

        private readonly ISertiDbContext _sertiDbContext;
        public UpdateParticipantCommandValidator(ISertiDbContext sertiDbContext)
        {
            _sertiDbContext = sertiDbContext;

            Include(new UpdateParticipantRequestValidator());
            RuleFor(r => r.Id).MustAsync((command, value, ctx, token) => NotExist(command, value, ctx, token)).WithMessage("_");
        }

        private async Task<bool> NotExist(UpdateParticipantCommand command, Guid value, ValidationContext<UpdateParticipantCommand> ctx, CancellationToken token)
        {
            var data = _sertiDbContext.Participants.AsNoTracking().FirstOrDefault(w => w.Id == command.Id);
            if (data == null)
            {
                ctx.AddFailure(ValidatorLang.NotExist);
                return false;
            }
            return true;
        }

    }
}
