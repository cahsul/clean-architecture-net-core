using Domain.Entities;
using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.X.Interfaces.Persistence
{
    public interface IIdentityDbContext
    {
        DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Domain.Entities.Identity.Menu> Menus { get; set; }
        public DbSet<MenuRole> MenuRoles { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        public DatabaseFacade Database { get; }
        DbContext Instance { get; }
    }
}
