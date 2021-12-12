using System;
using System.Collections.Generic;
using System.Text;
using Domain.X.Entities;

namespace Domain.Entities.Identity
{
    public class Menu : AuditableEntity<Guid>
    {
        public Guid? ParentId { get; set; }
        public int Order { get; set; }
        public string Label { get; set; }
        public string MenuKey { get; set; } // 
        public string Url { get; set; }
        public string MenuAction { get; set; }// aksi apa saja yang dimiliki

        public bool IsMenu => Url != null;


    }
}
