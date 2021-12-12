using Blazored.LocalStorage;
using Devextreme;
using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Serti.Client;
using Serti.Client.Api;
using Serti.Client.X.Extensions;
using Serti.Client.X.Helpers;
using Serti.Client.X.Services;
using Toastr;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


// Supply HttpClient instances that include access tokens when making requests to the server project
//builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Serti.ServerAPI"));


//
builder.Services.AddLocalization();
builder.Services.AddBlazoredLocalStorage();

//
builder.Services.AddTransient<Appsettings>();
builder.Services.AddTransient<EventApi>();
builder.Services.AddTransient<IdentityApi>();
builder.Services.AddTransient<UserApi>();
builder.Services.AddTransient<MenuApi>();

//
builder.Services.AddTransient<LocalStorageService>();

// plugin
builder.Services.AddToastr();
builder.Services.AddDevextreme();
builder.Services.AddFluxor(o => o.ScanAssemblies(typeof(Program).Assembly)); // https://dev.to/mr_eking/advanced-blazor-state-management-using-fluxor-part-2-io7
var host = builder.Build();
await host.SetDefaultCulture();


await builder.Build().RunAsync();
