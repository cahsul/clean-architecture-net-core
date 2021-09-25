using Application._.Interfaces.Persistence;
using Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Providers.MsSql.Identity
{
    public class MsSqlIdentityDbContext : IdentityDbContext, IIdentityDbContext
    {

        public MsSqlIdentityDbContext(
           DbContextOptions<MsSqlIdentityDbContext> options,
           Application._.Interfaces.Identity.IIdentity identity) : base(options)
        {
            _identity = identity;
        }

        public MsSqlIdentityDbContext(DbContextOptions<MsSqlIdentityDbContext> options) : base(options)
        {
        }
    }
}
