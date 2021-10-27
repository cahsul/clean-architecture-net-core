using Application.X.Interfaces.Identity;
using Domain.X;
using Domain.X.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.Todo;

namespace Infrastructure.Persistence.DbContexts
{
    /// <summary>
    /// databse TODO
    /// </summary>
    public class TodoDbContext : DbContext
    {
        protected IIdentity _identity;

        public TodoDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Todo> Todos { get; set; }



        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTimeOffset.Now;
                        entry.Entity.CreatedBy = _identity.Email;
                        entry.Entity.IsDeleted = false;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedDate = DateTimeOffset.Now;
                        entry.Entity.ModifiedBy = _identity.Email;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyAllConfigurationsFromNameSpace("Infrastructure.Persistence.Providers.MsSql.Todo.Config");
        }
    }
}
