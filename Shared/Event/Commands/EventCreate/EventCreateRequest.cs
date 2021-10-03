using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.Localization;
using Shared.Event.Resources;
using Shared.Todos.Resources;
using System.Resources;
using System.Reflection;
using System.Globalization;

namespace Shared.Event.Commands.EventCreate
{
    public class EventCreateRequest
    {
        public string EventName { get; set; }
        public string DateStart { get; set; }
        public string TimeStart { get; set; }

        public string DateFinish { get; set; }
        public string TimeFinish { get; set; }
    }

    public class EventCreateModelValidator : AbstractValidator<EventCreateRequest>
    {

        public EventCreateModelValidator()
        {
            RuleFor(r => r.EventName).NotEmpty().WithName(EventLang.Form_EventName);
            RuleFor(r => r.DateStart).NotEmpty().WithName(EventLang.Form_DateStart);
            RuleFor(r => r.TimeStart).NotEmpty().WithName(EventLang.Form_TimeStart);
            RuleFor(r => r.DateFinish).NotEmpty().WithName(EventLang.Form_DateFinish);
            RuleFor(r => r.TimeFinish).NotEmpty().WithName(EventLang.Form_TimeFinish);
        }
    }
}
