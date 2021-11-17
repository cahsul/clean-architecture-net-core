using Blazored.LocalStorage;
using Client;
using Client.Api;
using Client.X.Extensions;
using Client.X.Services;
using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Toastr;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//
builder.Services.AddLocalization();
builder.Services.AddBlazoredLocalStorage();

//
builder.Services.AddTransient<EventApi>();
builder.Services.AddTransient<IdentityApi>();
builder.Services.AddTransient<Appsettings>();

//
builder.Services.AddTransient<LocalStorageService>();



// AddFluxor
var currentAssembly = typeof(Program).Assembly;
builder.Services.AddFluxor(options => options.ScanAssemblies(currentAssembly));

//
builder.Services.AddToastr();


//await builder.Build().RunAsync();
var host = builder.Build();
await host.SetDefaultCulture();
await host.RunAsync();
