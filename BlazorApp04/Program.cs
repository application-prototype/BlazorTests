using BlazorApp04.Components;
using Microsoft.Identity.Web;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<IRequestService, RequestService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration, "AzureAd")
    .EnableTokenAcquisitionToCallDownstreamApi()
    .AddDownstreamApi("TemplateApi", builder.Configuration.GetSection("DownstreamAPI"))
    .AddInMemoryTokenCaches();

builder.Services.AddDbContext<IAppDbContext, AppDbContext>(options =>
        options.UseNpgsql("Server=pandpostgresql.postgres.database.azure.com;Database=pandurx;Port=5432;User Id=dbadmin;Password=P@ssw0rd;Ssl Mode=VerifyFull;"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
