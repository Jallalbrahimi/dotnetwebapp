using Microsoft.EntityFrameworkCore;
using WebApp.Api.Endpoints;
using WebApp.Identity.Extensions;
using WebApp.Identity.Persistence;
using WebApp.Infrastructure.Extensions;
using WebApp.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

var defaultConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
builder.Services.AddInfrastructure(defaultConnectionString);
var identityConnectionString = builder.Configuration.GetConnectionString("IdentityConnection") ?? string.Empty;
builder.Services.AddIdentityInfrastructure(identityConnectionString);

builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Automatically apply migrations (optional)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
    var identityDbContext = scope.ServiceProvider.GetRequiredService<ApplicationIdentityDbContext>();
    identityDbContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
    app.UseHttpsRedirection();
}

app.UseStaticFiles();

app.UseAuthentication(); 
app.UseAuthorization();

// Register endpoints
app.MapGet("/", () => "Hello World!");
app.MapGet("/protected", () => "This is a protected resource")
    .RequireAuthorization();

app.MapPublicationsEndpoints();
app.MapAuthenticationEndpoints();
// app.MapGroup("/auth").MapIdentityApi<ApplicationUser>();

app.Run();


