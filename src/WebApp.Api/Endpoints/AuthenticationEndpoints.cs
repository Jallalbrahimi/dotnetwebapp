using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using WebApp.Application.Features.Authentication.Commands;
using WebApp.Application.Mediator;
using WebApp.Domain.Entities;
using WebApp.Identity.Entities;

namespace WebApp.Api.Endpoints;

public static class AuthenticationEndpoints
{
    public static void MapAuthenticationEndpoints(this IEndpointRouteBuilder app)
    {
        // TODO : handle exceptions
        

        
        app.MapPost("/auth/register", async (RegisterCommand command, UserManager<ApplicationUser> userManager) =>
        {
            try
            {
                var user = new ApplicationUser() { Id = Guid.NewGuid(), UserName = command.Email, Email = command.Email, FirstName = command.FirstName, LastName = command.LastName };
                var result = await userManager.CreateAsync(user, command.Password);
                
                return result.Succeeded ? Results.Ok() : Results.InternalServerError(result.Errors);
            }
            catch (Exception e)
            {
                return Results.InternalServerError(e.Message);
            }
        });
        
        
        app.MapPost("/auth/login", async (LoginCommand command, SignInManager<ApplicationUser> signInManager) =>
        {
            try
            {
                if (string.IsNullOrWhiteSpace(command.Email) || string.IsNullOrWhiteSpace(command.Password))
                    return Results.BadRequest("Email and password required.");
                
                var result = await signInManager.PasswordSignInAsync(
                    command.Email,
                    command.Password,
                    isPersistent: command.RememberMe,
                    lockoutOnFailure: false);

                return result.Succeeded ? Results.Ok() : Results.Unauthorized();
            }
            catch (Exception e)
            {
                return Results.InternalServerError(e.Message);
            }
            
        });

        app.MapPost("/auth/logout", async (SignInManager<ApplicationUser> signInManager) =>
        {
            try
            {
                await signInManager.SignOutAsync();
                return Results.Ok("Logged out");
            }
            catch (Exception e)
            {
                return Results.InternalServerError(e.Message);
            }
        });
    }
}