using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.X.Interfaces
{
    public interface IAuditableEntity
    {
        bool IsDeleted { get; set; } // status untuk data terhapus
        DateTimeOffset? CreatedDate { get; set; } // tanggal data di buat
        string CreatedBy { get; set; } // data dibuat oleh siapa
        DateTimeOffset? ModifiedDate { get; set; } // tanggal data diubah
        string ModifiedBy { get; set; } // data diubah oleh siapa
    }
}
