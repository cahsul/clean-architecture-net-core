using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.X.Responses;

namespace Shared.Event.Queries.GetSpeakers
{
    public class GetSpeakersResponse : BaseResponse<Guid>
    {
        public Guid? EventId { get; set; }
        public string SpeakerName { get; set; }
        public string Topics { get; set; }
        public string Institution { get; set; }
    }
}
