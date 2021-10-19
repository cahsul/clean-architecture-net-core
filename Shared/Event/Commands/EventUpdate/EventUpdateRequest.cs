using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Event.Commands.EventUpdate
{
    public class EventUpdateRequest
    {
        public Guid Id { get; set; }
        public string EventName { get; set; }
    }
}
