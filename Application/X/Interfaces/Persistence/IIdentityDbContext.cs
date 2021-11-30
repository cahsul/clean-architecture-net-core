using Domain.Entities;
using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
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
        public DbSet<Menu> Menus { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
