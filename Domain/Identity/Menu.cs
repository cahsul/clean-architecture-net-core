using System;
using System.Collections.Generic;
using System.Text;
using Domain.X.Entities;

namespace Domain.Entities.Identity
{
    public class Menu : AuditableEntity<Guid>
    {
        public string MenuName { get; set; } // nama menu
        public string Url { get; set; }

    }
}
