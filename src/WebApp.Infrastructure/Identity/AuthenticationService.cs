using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using WebApp.Application.Features.Authentication.Interfaces;
using WebApp.Domain.Entities;

namespace WebApp.Infrastructure.Identity;

public class AuthenticationService(UserManager<ApplicationUser> userManager, IConfiguration config)
    : IAuthenticationService
{
    private readonly IConfiguration _config = config;

    public async Task<ApplicationUser?> AuthenticateAsync(string email, string password)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user == null)
        {
            return null;
        }

        var areCredentialsOk = await userManager.CheckPasswordAsync(user, password);
        return areCredentialsOk ? user : null;
    }

    public async Task<bool> RegisterAsync(ApplicationUser user, string password)
    {
        user.Id = Guid.NewGuid();
        var result = await userManager.CreateAsync(user, password);

        //TODO: Use another result type
        return result?.Succeeded ?? false;
    }

    public async Task<ApplicationUser?> GetUserByEmailAsync(string email)
    {
        return await userManager.FindByEmailAsync(email);
    }
}
    
