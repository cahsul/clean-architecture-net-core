using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.X.Responses;

namespace Shared.Event.Queries.GetEvents
{
    public class GetEventsResponse : BaseResponse<Guid>
    {
        public string EventName { get; set; }

    }
}
