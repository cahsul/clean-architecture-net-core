using System;
using Domain.X.Entities;
using Shared.Event.Enums;

namespace Domain.Entities.Serti
{
    /// <summary>
    /// acara acara yang yang dimiliki penyelenggara
    /// </summary>
    public class Event : AuditableEntity<Guid>
    {
        public string EventName { get; set; } // nama acara 
        public string EventStatus { get; set; } // staus
        public string Poster { get; set; } // poster event nya


    }
}
