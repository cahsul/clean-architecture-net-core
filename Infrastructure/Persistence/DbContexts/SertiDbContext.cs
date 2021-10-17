using Application.X.Interfaces.Identity;
using Domain.X;
using Domain.X.Interfaces;
using Domain.Entities;
using Domain.Entities.Serti;
using Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.DbContexts
{
    /// <summary>
    /// databse serti
    /// </summary>
    public class SertiDbContext : DbContext
    {
        protected IIdentity _identity;

        public SertiDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Event> Events { get; set; }



        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTimeOffset.UtcNow;
                        entry.Entity.CreatedBy = _identity.Email;
                        entry.Entity.IsDeleted = false;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedDate = DateTimeOffset.UtcNow;
                        entry.Entity.ModifiedBy = _identity.Email;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }



    }
}
