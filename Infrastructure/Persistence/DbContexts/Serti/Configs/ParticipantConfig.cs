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
    public class ParticipantConfig : IEntityTypeConfiguration<Participant>
    {

        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.Auditable();
            builder.ToTable("Participant", "Organizer");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasDefaultValueSql("uuid_generate_v4()");
            builder.Property(p => p.ParticipantName).HasMaxLength(400);
        }
    }
}
