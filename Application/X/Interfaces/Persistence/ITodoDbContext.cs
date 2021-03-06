using Domain.Entities;
using Domain.Entities.Todo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.X.Interfaces.Persistence
{
    public interface ITodoDbContext
    {
        public DbSet<Todo> Todos { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
