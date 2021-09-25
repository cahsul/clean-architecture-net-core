using Domain._;
using Domain._.Interfaces;
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
using Application._.Interfaces.Identity;

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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyAllConfigurationsFromNameSpace("Infrastructure.Persistence.Providers.MsSql.Identity.Config");
            builder.Entity<IdentityUser>(entity => { entity.ToTable(name: "Users", schema: "Identity"); });
            builder.Entity<IdentityRole>(entity => { entity.ToTable(name: "Roles", schema: "Identity"); });
            builder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable("UserRoles", schema: "Identity"); });
            builder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable("UserClaims", schema: "Identity"); });
            builder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable("UserLogins", schema: "Identity"); });
            builder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable("RoleClaims", schema: "Identity"); });
            builder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("UserTokens", schema: "Identity"); });

        }
    }


}
