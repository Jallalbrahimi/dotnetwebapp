using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Identity.Entities;

namespace WebApp.Identity.Persistence;

public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    
    public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Rename tables
        modelBuilder.Entity<ApplicationUser>().ToTable("Users");
        modelBuilder.Entity<ApplicationRole>().ToTable("Roles");
        modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles");
        modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
        modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");
        modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
        modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");

        // Seed initial roles using HasData
        var adminRoleId = Guid.Parse("22cc93f8-6e00-4f8e-b890-daf18d264c6e");
        var userRoleId = Guid.Parse("675416f3-7659-4539-9a52-65c6221afa88");
        var managerRoleId = Guid.Parse("535d4482-7f9e-45a3-8748-c87e58c6e8e7");
        var guestRoleId = Guid.Parse("c70d061f-4010-4a61-b0df-aff039e97588");

        modelBuilder.Entity<ApplicationRole>().HasData(
            new ApplicationRole
            {
                Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN",
                Description = "Administrator role with full permissions.", IsActive = true,
                CreatedOn = new DateTime(2025, 10, 16), ModifiedOn = new DateTime(2025, 10, 16),
            },
            new ApplicationRole
            {
                Id = userRoleId, Name = "User", NormalizedName = "USER", Description = "Standard user role.",
                IsActive = true, CreatedOn = new DateTime(2025, 10, 16), ModifiedOn = new DateTime(2025, 10, 16),
            },
            new ApplicationRole
            {
                Id = managerRoleId, Name = "Manager", NormalizedName = "MANAGER",
                Description = "Manager role with moderate permissions.", IsActive = true,
                CreatedOn = new DateTime(2025, 10, 16), ModifiedOn = new DateTime(2025, 10, 16),
            },
            new ApplicationRole
            {
                Id = guestRoleId, Name = "Guest", NormalizedName = "GUEST",
                Description = "Guest role with limited access.", IsActive = true,
                CreatedOn = new DateTime(2025, 10, 16),
                ModifiedOn = new DateTime(2025, 10, 16),
            }
        );
    }

}