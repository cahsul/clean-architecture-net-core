using System;
using Domain._.Entities;

namespace Domain.Entities.Serti
{
    /// <summary>
    /// acara acara yang yang dimiliki penyelenggara
    /// </summary>
    public class Event : AuditableEntity<Guid>
    {

        public string EventName { get; set; } // nama acara 


    }
}
