using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.X.Requests;

namespace Shared.Event.Queries.GetEvent
{
    public class GetEventRequest : BaseRequest
    {
        public Guid Id { get; set; }
    }
}
