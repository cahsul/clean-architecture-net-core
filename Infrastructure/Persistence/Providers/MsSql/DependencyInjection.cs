using Application._.Interfaces.Persistence;
using Infrastructure.Persistence.Providers.MsSql.Identity;
using Infrastructure.Persistence.Providers.MsSql.Todo;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Providers.MsSql
{
    // TODO : satu interface punya banyak yang pake untuk DI nya speerti apa
    public static class DependencyInjection
    {
        public static IServiceCollection AddMsSqlDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            // TODO : CONFIG
            services.AddDbContext<MsSqlTodoDbContext>(options => { options.UseSqlServer("Data Source=194.233.70.37,7433;Initial Catalog=Todo;User ID=sa;Password=Cay.12123;"); });
            services.AddScoped<ITodoDbContext>(provider => provider.GetService<MsSqlTodoDbContext>());

            services.AddDbContext<MsSqlIdentityDbContext>(options => { options.UseSqlServer("Data Source=194.233.70.37,7433;Initial Catalog=Todo;User ID=sa;Password=Cay.12123;"); });
            services.AddScoped<IIdentityDbContext>(provider => provider.GetService<MsSqlIdentityDbContext>());


            services.AddIdentityCore<IdentityUser>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 1;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

            }).AddEntityFrameworkStores<MsSqlIdentityDbContext>()
               .AddDefaultTokenProviders();

            //DatabaseConnectionsConfig databaseConnections = configuration.GetSection("DatabaseConnections").Get<DatabaseConnectionsConfig>();

            //foreach (DatabaseConnection dbConn in databaseConnections.List)
            //{
            //    switch (dbConn.ConnectionName)
            //    {
            //        case "Main":
            //            services.AddDbContext<MainDbContext>(options => DbContextOptions(options, dbConn));
            //            services.AddScoped<IMainDbContext>(provider => provider.GetService<MainDbContext>());
            //            break;
            //        case "Identity":
            //            services.AddDbContext<IdentityContext>(options => DbContextOptions(options, dbConn));
            //            services.AddScoped<IIdentityContext>(provider => provider.GetService<IdentityContext>());
            //            break;
            //    }
            //}

            return services;
        }
    }
}
