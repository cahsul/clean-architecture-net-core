using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Shared.Event.Commands.EventCreate;

namespace Application.Event.Commands.EventCreate
{
    public class EventCreateValidator : AbstractValidator<EventCreateCommand>
    {
        public EventCreateValidator()
        {
            Include(new EventCreateModelValidator());
            RuleFor(r => r.EventName).MinimumLength(10);
        }
    }
}
