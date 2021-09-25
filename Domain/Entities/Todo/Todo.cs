using Domain._.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Todo : AuditableEntity<Guid>
    {
        // berisi hal apa yang ingin dilakukan 
        public string Title { get; set; }
    }
}
