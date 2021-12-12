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
    internal class MenuRoleConfig : IEntityTypeConfiguration<MenuRole>
    {
        public void Configure(EntityTypeBuilder<MenuRole> builder)
        {
            builder.Auditable();
            builder.ToTable("MenuRole", "Identity");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasDefaultValueSql("uuid_generate_v4()");
            builder.Property(p => p.Action).HasMaxLength(200);
        }
    }
}
