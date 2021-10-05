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

        //public List<EventCreate_Speaker> Speakers { get; set; } = new();

        public DateTimeOffset? DateStart { get; set; }
        public string TimeStart { get; set; }

        public DateTimeOffset? DateFinish { get; set; }
        public string TimeFinish { get; set; }
    }

    public class EventCreate_Speaker
    {
        public string Speaker { get; set; }
    }

    public class EventCreateModelValidator : AbstractValidator<EventCreateRequest>
    {

        public EventCreateModelValidator()
        {
            RuleFor(r => r.EventName).NotEmpty().WithName(EventLang.Form_EventName);
            //RuleFor(r => r.Speakers).NotNull().SetValidator(new EventCreate_SpeakerValidator());


            RuleFor(r => r.DateStart).NotEmpty().WithName(EventLang.Form_DateStart);
            RuleFor(r => r.TimeStart).NotEmpty().WithName(EventLang.Form_TimeStart);
            RuleFor(r => r.DateFinish).NotEmpty().WithName(EventLang.Form_DateFinish);
            RuleFor(r => r.TimeFinish).NotEmpty().WithName(EventLang.Form_TimeFinish);
        }
    }

    public class EventCreate_SpeakerValidator : AbstractValidator<EventCreate_Speaker>
    {

        public EventCreate_SpeakerValidator()
        {
            RuleFor(r => r.Speaker).NotNull().WithName(EventLang.Form_Speaker);
        }
    }
}
