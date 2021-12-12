using Application.X.Interfaces.Identity;
using Application.X.Interfaces.Jwt;
using Application.X.Interfaces.Library;
using Application.X.Interfaces.Persistence;
using Application.X.Interfaces.UploadFile;
using Infrastructure.Jwt;
using Infrastructure.Persistence;
using Infrastructure.Persistence.DbContexts;
//using Infrastructure.Persistence.Providers.MsSql;
//using Infrastructure.Persistence.Providers.MySql;
using Infrastructure.X.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Shared.X.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // add setting to variable
            var baseDirectory = AppContext.BaseDirectory;
            var r = new StreamReader($"{baseDirectory}/InfrastructureSettings.json");
            var jsonString = r.ReadToEnd();
            var settings = jsonString.ToJsonDeserialize<InfrastructureSettings>();

            // add setting to ConfigurationBuilder
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"{baseDirectory}/InfrastructureSettings.json", optional: false)
                .AddEnvironmentVariables()
                .Build();

            services.Configure<InfrastructureSettings>(configuration);


            //services.AddMsSqlDatabase();
            services.AddPersistence(settings);

            // Libs
            services.AddScoped<IUploadFile, UploadFile.UploadFile>();
            services.AddScoped<IJwtGenerator, JwtGenerator>();
            services.AddScoped<ICryptography, Cryptography.Cryptography>();
            services.AddScoped<IIdentity, Identity>();

            services.AddSingleton<ITodoDbContextDapper, TodoDbContextDapper>();
            services.AddSingleton<InfrastructureSettings>();

            // autentikasi menggunan JWT 
            // TODO : config
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = "audience",
                ValidIssuer = "issuer",
                RequireExpirationTime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Jwt.Secret)),
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero,

            };

            var events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    context.Token = context.Request.Cookies["JwtToken"];
                    return Task.CompletedTask;
                }
            };

            services.AddAuthentication(auth =>
                {
                    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = tokenValidationParameters;
                    options.Events = events;
                });



            return services;
        }
    }
}

