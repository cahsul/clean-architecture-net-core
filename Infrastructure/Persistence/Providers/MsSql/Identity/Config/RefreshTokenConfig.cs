using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Identity;
using Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Providers.MsSql.Identity.Config
{
    internal class RefreshTokenConfig : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.Auditable();
            builder.ToTable("RefreshToken", "Identity");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasDefaultValueSql("newid()");

            builder.Property(p => p.UserId).HasMaxLength(100);
            builder.Property(p => p.JwtToken).HasMaxLength(3000);
            builder.Property(p => p.Token).HasMaxLength(3000);
            builder.Property(p => p.ReplacedByToken).HasMaxLength(3000);
            builder.Property(p => p.ReasonRevoked).HasMaxLength(3000);


        }
    }
}
