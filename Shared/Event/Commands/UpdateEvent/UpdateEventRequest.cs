using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Shared.Event.Resources;
using Shared.X.Requests;

namespace Shared.Event.Commands.UpdateEvent
{
    public class UpdateEventRequest : BaseRequest
    {
        public Guid? Id { get; set; }
        public string EventName { get; set; }
        public IFormFile Poster { get; set; }
    }

    public class EventUpdateRequestValidator : AbstractValidator<UpdateEventRequest>
    {
        public EventUpdateRequestValidator()
        {
            RuleFor(r => r.EventName).NotNull().WithName(EventLang.Form_EventName);
        }
    }
}
