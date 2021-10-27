using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.X.Interfaces.Persistence;
using Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.DbContexts.Serti
{
    public class SertiPostgreSqlDbContext : SertiDbContext, ISertiDbContext
    {
        public SertiPostgreSqlDbContext(
               DbContextOptions<SertiPostgreSqlDbContext> options,
               Application.X.Interfaces.Identity.IIdentity identity) : base(options)
        {
            _identity = identity;
        }

        public SertiPostgreSqlDbContext(DbContextOptions<SertiPostgreSqlDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyAllConfigurationsFromNameSpace("Infrastructure.Persistence.DbContexts.Serti.Config");
        }
    }
}
