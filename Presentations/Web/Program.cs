using Fluxor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web.Api;
using Web.Shared.Components;
using Web.Extensions;
using Blazored.LocalStorage;

namespace Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddLocalization();
            builder.Services.AddBlazoredLocalStorage();


            // AddFluxor
            var currentAssembly = typeof(Program).Assembly;
            builder.Services.AddFluxor(options => options.ScanAssemblies(currentAssembly));

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddTransient<NotificationComponent>();
            builder.Services.AddTransient<TodoApi>();

            // AddAntDesign
            builder.Services.AddAntDesign();

            var host = builder.Build();
            await host.SetDefaultCulture();

            await host.RunAsync();
        }
    }
}
