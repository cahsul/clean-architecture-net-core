using Domain.X.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Extensions
{
    /// <summary>
    /// untuk entity yang memiliki Auditable, gunakan class ini di config nya
    /// </summary>
    public static class AuditableExtension
    {
        public static void Auditable<TEntity>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : class, IAuditableEntity
        {
            builder.Property(e => e.CreatedBy).HasMaxLength(100).IsRequired();
            builder.Property(e => e.ModifiedBy).HasMaxLength(100).IsRequired(false);

            builder.Property(e => e.CreatedDate).IsRequired();
            builder.Property(e => e.ModifiedDate).IsRequired(false);
        }

    }
}
