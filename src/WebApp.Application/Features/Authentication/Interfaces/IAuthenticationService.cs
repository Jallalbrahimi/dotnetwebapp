using WebApp.Domain.Entities;

namespace WebApp.Application.Features.Authentication.Interfaces;

public interface IAuthenticationService
{
    Task<ApplicationUser?> AuthenticateAsync(string email, string password);
    Task<bool> RegisterAsync(ApplicationUser user, string password);
    Task<ApplicationUser?> GetUserByEmailAsync(string email);
}