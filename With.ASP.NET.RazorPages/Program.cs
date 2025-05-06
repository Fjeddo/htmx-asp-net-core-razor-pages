using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using With.ASP.NET.RazorPages;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//////
// Authentication/authorization
builder.Services
    .AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration, "AzureAd");

builder.Services
    .AddAuthorization(options => options.AddPolicy("Return401", policy => policy.RequireAuthenticatedUser()))
    .AddScoped<Return401AuthorizationFilter>();
//////
//////

//////
// SignalR
builder.Services.AddSignalR();
//////
//////

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

//////
// Authentication/authorization
app
    .UseAuthentication()
    .UseAuthorization();
//////
//////

app.MapStaticAssets();
app.MapRazorPages().WithStaticAssets();

//////
// SignalR
app.MapHub<MessageHub>("/messagehub");
//////
//////


app.Run();
