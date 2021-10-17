using Domain.Entities;
using Domain.Entities.Serti;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.X.Interfaces.Persistence
{
    public interface ISertiDbContext
    {
        public DbSet<Domain.Entities.Serti.Event> Events { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
