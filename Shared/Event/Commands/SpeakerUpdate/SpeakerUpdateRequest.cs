using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Shared.Event.Resources;
using Shared.X.Requests;

namespace Shared.Event.Commands.SpeakerUpdate
{
    public class SpeakerUpdateRequest : BaseRequest
    {
        public Guid? Id { get; set; }
        public string SpeakerName { get; set; }
        public string Topics { get; set; }
        public string Institution { get; set; }

        public bool EditMode { get; set; } = false; // true = form create tampil di layar
        public Guid? EventId { get; set; }
    }

    public class SpeakerUpdateValidator : AbstractValidator<SpeakerUpdateRequest>
    {
        public SpeakerUpdateValidator()
        {
            // TODO : lang
            RuleFor(r => r.SpeakerName).NotNull().WithName(EventLang.Form_Speaker);
            RuleFor(r => r.Topics).NotNull().WithName("<Topics>");
            RuleFor(r => r.Institution).NotNull().WithName("<Institution>");
        }
    }
}
