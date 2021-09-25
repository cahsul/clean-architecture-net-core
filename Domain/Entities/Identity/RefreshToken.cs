using System;
using System.Collections.Generic;
using System.Text;
using Domain._.Entities;

namespace Domain.Entities.Identity
{
    public class RefreshToken : AuditableEntity<Guid>
    {
        public string UserId { get; set; }
        public string JwtToken { get; set; }
        public string Token { get; set; } // refresh token yang terbentuk. seharusnya namanya RefreshToken tapi ndak boleh sama dengan nama class
        public string ReplacedByToken { get; set; } // refresh token sebelumnya
        public string ReasonRevoked { get; set; } // alasan di revoke
        public DateTimeOffset? ExpiryDate { get; set; } // waktu expired
        public DateTimeOffset? RevokedDate { get; set; } // waktu revoke
        public DateTimeOffset? UsedDate { get; set; } // waktu refresh token digunakan


        public bool IsExpired => DateTimeOffset.Now >= ExpiryDate;
        public bool IsRevoked => RevokedDate != null;
        public bool IsUsed => UsedDate != null;
        public bool IsActive => !IsRevoked && !IsExpired && !IsUsed;
    }
}
