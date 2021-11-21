using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Serti.Client;
using Serti.Client.Api;
using Serti.Client.X.Services;
using Toastr;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("Serti.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
//.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Serti.ServerAPI"));


//
//builder.Services.AddLocalization();
builder.Services.AddBlazoredLocalStorage();

//
builder.Services.AddTransient<Appsettings>();
builder.Services.AddTransient<EventApi>();
builder.Services.AddTransient<IdentityApi>();
builder.Services.AddTransient<UserApi>();

//
builder.Services.AddTransient<LocalStorageService>();

//
builder.Services.AddToastr();

builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();
