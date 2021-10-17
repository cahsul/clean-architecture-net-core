using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application.X.Interfaces.Persistence;
using Infrastructure.Persistence.Providers.PostgreSql;
using Infrastructure.Persistence.Providers.PostgreSql.Serti;
using Infrastructure.X.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.X.Extensions;

namespace Infrastructure.Persistence.Providers.MySql
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPostgreSqlDatabase(this IServiceCollection services, InfrastructureSettings settings)
        {
            services.AddDbContext<IdentityPostgreSqlDbContext>(options => { options.UseNpgsql(settings.IdentityUser.ConnectionStrings); });
            services.AddScoped<IIdentityDbContext>(provider => provider.GetService<IdentityPostgreSqlDbContext>());
            services.AddIdentityCore<Microsoft.AspNetCore.Identity.IdentityUser>(options =>
            {
                options.Password.RequireDigit = settings.IdentityUser.Options.Password.RequireDigit;
                options.Password.RequireLowercase = settings.IdentityUser.Options.Password.RequireLowercase;
                options.Password.RequiredLength = settings.IdentityUser.Options.Password.RequiredLength;
                options.Password.RequireNonAlphanumeric = settings.IdentityUser.Options.Password.RequireNonAlphanumeric;
                options.Password.RequireUppercase = settings.IdentityUser.Options.Password.RequireUppercase;

                options.SignIn.RequireConfirmedAccount = settings.IdentityUser.Options.SignIn.RequireConfirmedAccount;
                options.SignIn.RequireConfirmedEmail = settings.IdentityUser.Options.SignIn.RequireConfirmedEmail;
                options.SignIn.RequireConfirmedPhoneNumber = settings.IdentityUser.Options.SignIn.RequireConfirmedPhoneNumber;

            }).AddEntityFrameworkStores<IdentityPostgreSqlDbContext>()
               .AddDefaultTokenProviders();


            services.AddDbContext<SertiPostgreSqlDbContext>(options => { options.UseNpgsql(settings.ConnectionStrings.Serti); });
            services.AddScoped<ISertiDbContext>(provider => provider.GetService<SertiPostgreSqlDbContext>());


            return services;
        }
    }
}
