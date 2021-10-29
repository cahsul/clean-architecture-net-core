using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.X.Interfaces.Persistence;
using FluentValidation;
using Shared.Participant.Commands.CreateParticipant;

namespace Application.Participant.Commands.CreateParticipant
{
    public class CreateParticipantCommandValidator : AbstractValidator<CreateParticipantCommand>
    {

        private readonly ISertiDbContext _sertiDbContext;
        public CreateParticipantCommandValidator(ISertiDbContext sertiDbContext)
        {
            _sertiDbContext = sertiDbContext;

            Include(new CreateParticipantRequestValidator());

            // TODO : eventID harus ada di tabel
            // TODO : CertificateTemplateId harus ada di tabel

            // ParticipantName Duplicate
            //When(r => !string.IsNullOrEmpty(r.ParticipantName), () =>
            //{
            //    RuleFor(r => r.ParticipantName)
            //    .MustAsync((command, value, ctx, token) => DuplicateParticipantName(command, value, ctx, token)).WithMessage("_");
            //});


        }

        private async Task<bool> DuplicateParticipantName(CreateParticipantCommand command, string value, ValidationContext<CreateParticipantCommand> ctx, CancellationToken token)
        {
            // find data by name
            var data = _sertiDbContext.Participants.FirstOrDefault(w => w.ParticipantName.Trim().ToLower() == command.ParticipantName.Trim().ToLower());
            if (data != null)
            {
                ctx.AddFailure("Tidak dapat membuat data yang sama");
                return false;
            }
            return true;
        }
    }
}
