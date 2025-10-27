using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WebApp.Identity.Persistence;

/// <summary>
/// Used by EF Core CLI tools to create the DbContext during design time.
/// </summary>
public class ApplicationIdentityDbContextFactory : IDesignTimeDbContextFactory<ApplicationIdentityDbContext>
{
    public ApplicationIdentityDbContext CreateDbContext(string[] args)
    {
        // Build configuration (looks for appsettings.json)
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // Needed for EF CLI
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        // Get connection string from configuration
        var connectionString = config.GetConnectionString("IdentityConnection");

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationIdentityDbContext>();
        optionsBuilder.UseSqlite(connectionString);

        return new ApplicationIdentityDbContext(optionsBuilder.Options);
    }
}