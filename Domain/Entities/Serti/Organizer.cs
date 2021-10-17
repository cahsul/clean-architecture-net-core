using System;
using System.Collections.Generic;
using System.Text;
using Domain.X.Entities;

namespace Domain.Entities.Serti
{
    /// <summary>
    /// data dari penyelanggara nya
    /// </summary>
    public class Organizer : AuditableEntity<Guid>
    {
        public string OrganizerType { get; set; } // tipe penyelenggara. PT, CV, Kampus, Lain - Lain
        public string Name { get; set; } // nama penyelenggara

    }
}
