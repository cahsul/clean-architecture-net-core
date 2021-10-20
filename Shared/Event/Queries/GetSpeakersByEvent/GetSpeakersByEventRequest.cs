using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.X.Requests;

namespace Shared.Event.Queries.GetSpeakersByEvent
{
    public class GetSpeakersByEventRequest : BaseRequest
    {
        public Guid EventId { get; set; }
    }
}
