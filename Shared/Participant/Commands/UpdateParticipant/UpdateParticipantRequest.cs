using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Shared.Participant.Resources;

namespace Shared.Participant.Commands.UpdateParticipant
{
    public class UpdateParticipantRequest
    {
        public Guid Id { get; set; }
        public Guid CertificateTemplateId { get; set; }
        public string ParticipantName { get; set; }
    }

    public class UpdateParticipantRequestValidator : AbstractValidator<UpdateParticipantRequest>
    {
        public UpdateParticipantRequestValidator()
        {
            RuleFor(r => r.ParticipantName).NotEmpty().WithName(ParticipantLang.Form_ParticipantName);
            RuleFor(r => r.CertificateTemplateId).NotEmpty().WithName(ParticipantLang.Form_Certificate);
        }
    }
}
