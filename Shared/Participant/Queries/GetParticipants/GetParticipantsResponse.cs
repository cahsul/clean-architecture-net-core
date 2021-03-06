using System;
using System.Collections.Generic;
using System.Text;
using Shared.X.Responses;

namespace Shared.Participant.Queries.GetParticipants
{
    public class GetParticipantsResponse : BaseResponse<Guid>
    {
        public Guid? EventId { get; set; }
        public Guid? CertificateTemplateId { get; set; }
        public Guid? OwnerId { get; set; }
        public string ParticipantName { get; set; }
    }
}
