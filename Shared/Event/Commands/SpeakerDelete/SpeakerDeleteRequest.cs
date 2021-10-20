using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.X.Requests;

namespace Shared.Event.Commands.SpeakerDelete
{
    public class SpeakerDeleteRequest : BaseRequest
    {
        public Guid Id { get; set; }
    }
}
