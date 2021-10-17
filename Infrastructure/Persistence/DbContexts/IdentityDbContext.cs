using Domain.X;
using Domain.X.Interfaces;
using Domain.Entities;
using IdentityCtx = Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Domain.Entities.Identity;
using Infrastructure.Persistence.Extensions;
using Application.X.Interfaces.Identity;

namespace Infrastructure.Persistence.DbContexts
{
    public class IdentityDbContext : IdentityCtx.IdentityDbContext
    {
        protected IIdentity _identity;

        protected IdentityDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTimeOffset.Now;
                        entry.Entity.CreatedBy = _identity?.Email;
                        entry.Entity.IsDeleted = false;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedDate = DateTimeOffset.Now;
                        entry.Entity.ModifiedBy = _identity?.Email;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }


    }


}
