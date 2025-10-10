using Microsoft.EntityFrameworkCore;
using WebApp.Api.Endpoints;
using WebApp.Infrastructure.Extensions;
using WebApp.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddInfrastructure();
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
builder.Services.AddPersistence(connectionString);

var app = builder.Build();

// Automatically apply migrations (optional)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

app.MapGet("/", () => "Hello World!");

// Register endpoints
app.MapPublicationsEndpoints();

app.Run();
