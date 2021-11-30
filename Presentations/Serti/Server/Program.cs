using System.Reflection;
using Application;
using Application.X.Interfaces;
using FluentValidation.AspNetCore;
using Infrastructure;
using Microsoft.AspNetCore.ResponseCompression;
using Serti.Server.X;
using Serti.Server.X.Extensions;
using Serti.Server.X.Filters;

var builder = WebApplication.CreateBuilder(args);

// csw
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));
builder.Services.AddSwagger();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ExceptionFilter>();
})
    .AddFluentValidation(fv =>
    {
        fv.DisableDataAnnotationsValidation = true;
        fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    });
builder.Services.AddScoped<IUser, User>();
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));



// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddLocalization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseCors("MyPolicy");
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSwaggerConfigure();

//var cultures = new List<CultureInfo> {
//                new CultureInfo("en-US"),
//                new CultureInfo("id-ID")
//            };
//app.UseRequestLocalization(options =>
//{
//    options.DefaultRequestCulture = new RequestCulture("en-US");
//    options.SupportedCultures = cultures;
//    options.SupportedUICultures = cultures;
//});


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
