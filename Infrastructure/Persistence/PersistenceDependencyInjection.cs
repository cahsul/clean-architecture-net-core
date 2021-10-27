using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.X.Interfaces.Persistence;
using Infrastructure.Persistence.DbContexts.Identity;
using Infrastructure.Persistence.DbContexts.Serti;
using Infrastructure.X.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence
{
    public static class PersistenceDependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, InfrastructureSettings settings)
        {
            // SERTI //
            services.AddDbContext<SertiPostgreSqlDbContext>(options => { options.UseNpgsql(settings.ConnectionStrings.Serti); });
            services.AddScoped<ISertiDbContext>(provider => provider.GetService<SertiPostgreSqlDbContext>());

            // IDENTITY //
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


            return services;
        }
    }
}
