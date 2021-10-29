using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Shared.Participant.Resources;

namespace Shared.Participant.Commands.CreateParticipant
{
    public class CreateParticipantRequest
    {
        public Guid EventId { get; set; }
        public Guid CertificateTemplateId { get; set; }
        public string ParticipantName { get; set; }
    }

    public class CreateParticipantRequestValidator : AbstractValidator<CreateParticipantRequest>
    {
        public CreateParticipantRequestValidator()
        {
            RuleFor(r => r.ParticipantName).NotEmpty().WithName(ParticipantLang.Form_ParticipantName);
            RuleFor(r => r.CertificateTemplateId).NotEmpty().WithName(ParticipantLang.Form_Certificate);
        }
    }
}
