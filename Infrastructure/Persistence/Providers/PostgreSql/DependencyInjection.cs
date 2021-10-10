using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application._.Interfaces.Persistence;
using Infrastructure.Persistence.Providers.PostgreSql;
using Infrastructure.Persistence.Providers.PostgreSql.Serti;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence.Providers.MySql
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPostgreSqlDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityPostgreSqlDbContext>(options => { options.UseNpgsql("User ID=postgres;Password=Cay.12123;Host=194.233.70.37;Port=7232;Database=Serti;"); });
            services.AddScoped<IIdentityDbContext>(provider => provider.GetService<IdentityPostgreSqlDbContext>());


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

            }).AddEntityFrameworkStores<IdentityPostgreSqlDbContext>()
               .AddDefaultTokenProviders();

            // TODO : CONFIG
            services.AddDbContext<SertiPostgreSqlDbContext>(options => { options.UseNpgsql("User ID=postgres;Password=Cay.12123;Host=194.233.70.37;Port=7232;Database=Serti;"); });
            services.AddScoped<ISertiDbContext>(provider => provider.GetService<SertiPostgreSqlDbContext>());


            return services;
        }
    }
}
