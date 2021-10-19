using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.X.Interfaces.Persistence;
using Domain.Entities.Serti;
using Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.DbContexts.Serti.Config
{
    public class EventSpeakerConfig : IEntityTypeConfiguration<EventSpeaker>
    {
        public void Configure(EntityTypeBuilder<EventSpeaker> builder)
        {
            builder.Auditable();
            builder.ToTable("EventSpeaker");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasDefaultValueSql("uuid_generate_v4()");
            builder.Property(p => p.SpeakerName).HasMaxLength(2000);
            builder.Property(p => p.Topics).HasMaxLength(2000);
            builder.Property(p => p.Institution).HasMaxLength(2000);
        }
    }
}
