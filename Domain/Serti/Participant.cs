using System;
using Domain.X.Entities;
using Shared.Event.Enums;

namespace Domain.Entities.Serti
{
    /// <summary>
    /// peserta yang mengikuti acara
    /// </summary>
    public class Participant : AuditableEntity<Guid>
    {
        public Guid? EventId { get; set; }
        public Guid? CertificateTemplateId { get; set; }
        public Guid? OwnerId { get; set; }
        public string ParticipantName { get; set; }


    }
}
