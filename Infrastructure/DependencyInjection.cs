using Application._.Interfaces.Identity;
using Application._.Interfaces.Jwt;
using Infrastructure.Jwt;
using Infrastructure.Persistence.Providers.MsSql;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddMsSqlDatabase(configuration);

            services.AddScoped<IJwtGenerator, JwtGenerator>();
            services.AddSingleton<IIdentity, Identity>();

            // autentikasi menggunan JWT 

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = "audience",
                ValidIssuer = "issuer",
                RequireExpirationTime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("a bb ccc dddd eeeee ffffff ggggggg hhhhhhhh iiiiiiiii")),
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero,

            };

            // services.AddSingleton(tokenValidationParameters);
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = tokenValidationParameters;
            });



            return services;
        }
    }
}

