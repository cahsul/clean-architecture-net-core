using System;
using Domain.X.Entities;

namespace Domain.Entities.Serti
{
    /// <summary>
    /// pembicara pada suatu event
    /// </summary>
    public class EventSpeaker : AuditableEntity<Guid>
    {
        public Guid EventId { get; set; }
        public string SpeakerName { get; set; } // nama pembicara 
        public string Topics { get; set; } // topik yang dibawakan
        public string Institution { get; set; } // asal institusi pembiacara
    }
}
