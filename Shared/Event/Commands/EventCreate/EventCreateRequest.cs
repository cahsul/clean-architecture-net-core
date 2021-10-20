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
using Shared.X.Requests;

namespace Shared.Event.Commands.EventCreate
{
    public class EventCreateRequest : BaseRequest
    {
        public string? EventName { get; set; }
        public List<Guid> SpeakersId { get; set; }
    }

    public class EventCreateModelValidator : AbstractValidator<EventCreateRequest>
    {

        public EventCreateModelValidator()
        {
        }
    }



    public class EventCreateTime
    {
        public Guid? Id { get; set; } = null;
        public bool EditMode { get; set; } = false; // true = form create tampil di layar
        public string Place { get; set; }
        public DateTimeOffset? DateStart { get; set; }
        public string TimeStart { get; set; }
        public DateTimeOffset? DateFinish { get; set; }
        public string TimeFinish { get; set; }
    }

    public class EventCreateTimeValidator : AbstractValidator<EventCreateTime>
    {
        public EventCreateTimeValidator()
        {
            // TODO : lang
            RuleFor(r => r.Place).NotEmpty().WithName("<place>");
            RuleFor(r => r.DateStart).NotEmpty().WithName(EventLang.Form_DateStart);
            RuleFor(r => r.TimeStart).NotEmpty().WithName(EventLang.Form_TimeStart);
            RuleFor(r => r.DateFinish).NotEmpty().WithName(EventLang.Form_DateFinish);
            RuleFor(r => r.TimeFinish).NotEmpty().WithName(EventLang.Form_TimeFinish);
        }
    }
}
