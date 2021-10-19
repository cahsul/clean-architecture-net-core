using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Event.Commands.SpeakerUpdate
{
    public class SpeakerUpdateRequest
    {
        public Guid Id { get; set; }
        public string SpeakerName { get; set; }
        public string Topics { get; set; }
        public string Institution { get; set; }
    }
}
