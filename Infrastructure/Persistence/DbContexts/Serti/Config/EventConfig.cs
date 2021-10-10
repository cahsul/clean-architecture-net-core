using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Serti;
using Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.DbContexts.Serti.Config
{
    public class EventConfig : IEntityTypeConfiguration<Event>
    {

        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Auditable();
            builder.ToTable("Event");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.EventName).HasMaxLength(2000);
        }
    }
}
