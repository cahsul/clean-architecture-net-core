using Domain._.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain._.Entities
{
    /// <summary>
    /// kerangka dasar untuk entty yang memiliki kolom kolom audit
    /// </summary>
    public abstract class AuditableEntity<T> : Entity<Guid>, IAuditableEntity
    {
        public bool IsDeleted { get; set; }

        public DateTimeOffset? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTimeOffset? ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }
    }
}
