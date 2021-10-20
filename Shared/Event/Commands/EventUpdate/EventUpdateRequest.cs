using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Shared.Event.Resources;
using Shared.X.Requests;

namespace Shared.Event.Commands.EventUpdate
{
    public class EventUpdateRequest : BaseRequest
    {
        public Guid? Id { get; set; }
        public string EventName { get; set; }
    }

    public class EventUpdateRequestValidator : AbstractValidator<EventUpdateRequest>
    {
        public EventUpdateRequestValidator()
        {
            RuleFor(r => r.EventName).NotNull().WithName(EventLang.Form_EventName);
        }
    }
}
