using System;
using System.Collections.Generic;
using System.Text;
using Domain.X.Entities;

namespace Domain.Entities.Identity
{
    public class MenuRole : AuditableEntity<Guid>
    {
        public Guid MenuId { get; set; }
        public Guid RoleId { get; set; }
        public string Action { get; set; }

    }
}
