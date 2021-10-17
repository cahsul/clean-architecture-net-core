using Domain.Entities;
using Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Providers.MsSql.Todo.Config
{

    public class TodoConfig : IEntityTypeConfiguration<Domain.Entities.Todo.Todo>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Todo.Todo> builder)
        {
            builder.Auditable();
            builder.ToTable("Todo");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasDefaultValueSql("newid()");
            builder.Property(p => p.Title).HasMaxLength(100);

        }
    }
}
