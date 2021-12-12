using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Identity;
using Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.DbContexts.Identity.Configs
{
    internal class MenuConfig : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.Auditable();
            builder.ToTable("Menu", "Identity");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasDefaultValueSql("uuid_generate_v4()");
            builder.Property(p => p.Label).HasMaxLength(100);
            builder.Property(p => p.MenuAction).HasMaxLength(500);

            builder.Property(p => p.MenuKey).HasMaxLength(50);
            builder.Property(p => p.Order).HasMaxLength(10);
            builder.Property(p => p.Url).HasMaxLength(100);
            builder.HasIndex(i => i.MenuKey).IsUnique();

        }
    }
}
