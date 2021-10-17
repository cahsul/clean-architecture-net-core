using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using API.X.Extensions;
using API.X.Filters;
using Application;
using FluentValidation.AspNetCore;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

builder.Services.AddSwagger();

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ExceptionFilter>();
})
.AddFluentValidation(fv =>
{
    fv.DisableDataAnnotationsValidation = true;
    fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});



builder.Services.AddLocalization();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseCors("MyPolicy");

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



var cultures = new List<CultureInfo> {
                new CultureInfo("en-US"),
                new CultureInfo("id-ID")
            };
app.UseRequestLocalization(options =>
{
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = cultures;
    options.SupportedUICultures = cultures;
});


app.UseSwaggerConfigure();

app.Run();
