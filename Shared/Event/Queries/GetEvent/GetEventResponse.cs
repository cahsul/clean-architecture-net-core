using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.X.Responses;

namespace Shared.Event.Queries.GetEvent
{
    public class GetEventResponse : BaseResponse<Guid>
    {
        public string EventName { get; set; }
    }
}
