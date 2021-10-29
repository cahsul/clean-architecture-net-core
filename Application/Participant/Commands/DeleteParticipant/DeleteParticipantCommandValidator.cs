using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.X.Interfaces.Persistence;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Shared.X.Resources;

namespace Application.Participant.Commands.DeleteParticipant
{
    public class DeleteParticipantCommandValidator : AbstractValidator<DeleteParticipantCommand>
    {

        private readonly ISertiDbContext _sertiDbContext;
        public DeleteParticipantCommandValidator(ISertiDbContext sertiDbContext)
        {
            _sertiDbContext = sertiDbContext;

            RuleFor(r => r.Id).MustAsync((command, value, ctx, token) => NotExist(command, value, ctx, token)).WithMessage("_");
        }

        private async Task<bool> NotExist(DeleteParticipantCommand command, Guid value, ValidationContext<DeleteParticipantCommand> ctx, CancellationToken token)
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
