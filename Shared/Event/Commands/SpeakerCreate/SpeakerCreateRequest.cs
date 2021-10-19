using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Event.Commands.SpeakerCreate
{
    public class SpeakerCreateRequest
    {
        public Guid EventId { get; set; }
        public string SpeakerName { get; set; }
        public string Topics { get; set; }
        public string Institution { get; set; }
    }
}
