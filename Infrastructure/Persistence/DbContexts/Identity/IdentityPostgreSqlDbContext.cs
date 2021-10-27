using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.X.Interfaces.Persistence;
using Infrastructure.Persistence.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.DbContexts.Identity
{
    public class IdentityPostgreSqlDbContext : IdentityDbContext, IIdentityDbContext
    {
        public IdentityPostgreSqlDbContext(
           DbContextOptions<IdentityPostgreSqlDbContext> options,
           Application.X.Interfaces.Identity.IIdentity identity) : base(options)
        {
            _identity = identity;
        }

        public IdentityPostgreSqlDbContext(DbContextOptions<IdentityPostgreSqlDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyAllConfigurationsFromNameSpace("Infrastructure.Persistence.DbContexts.Identity.Config");
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
