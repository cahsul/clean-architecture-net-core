using System;
using System.Collections.Generic;
using System.Text;
using Shared.X.Responses;

namespace Shared.Participant.Queries.GetEvents
{
    public class GetEventsResponse : BaseResponse<Guid>
    {
        public string EventName { get; set; }
        public int TotalParticipant { get; set; }

    }
}
