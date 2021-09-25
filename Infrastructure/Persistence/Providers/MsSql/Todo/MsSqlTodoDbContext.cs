using Application._.Interfaces.Persistence;
using Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Providers.MsSql.Todo
{
    public class MsSqlTodoDbContext : TodoDbContext, ITodoDbContext
    {
        public MsSqlTodoDbContext(
           DbContextOptions<MsSqlTodoDbContext> options,
           Application._.Interfaces.Identity.IIdentity identity) : base(options)
        {
            _identity = identity;
        }

        public MsSqlTodoDbContext(DbContextOptions<MsSqlTodoDbContext> options) : base(options)
        {
        }
    }
}
