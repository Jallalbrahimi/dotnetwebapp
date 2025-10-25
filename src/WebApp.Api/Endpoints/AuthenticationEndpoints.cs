using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using WebApp.Application.Features.Authentication.Commands;
using WebApp.Application.Mediator;
using WebApp.Domain.Entities;

namespace WebApp.Api.Endpoints;

public static class AuthenticationEndpoints
{
    public static void MapAuthenticationEndpoints(this IEndpointRouteBuilder app)
    {
        // TODO : handle exceptions
        

        
        app.MapPost("/auth/register", async (RegisterCommand command, IMediator mediator) =>
        {
            try
            {
                var result = await mediator.SendCommandAsync<RegisterCommand, bool>(command);
                return Results.Ok(result);
            }
            catch (Exception e)
            {
                return Results.InternalServerError(e.Message);
            }
        });
        
        
        app.MapPost("/auth/login", async (LoginCommand command, SignInManager<ApplicationUser> signInManager, IMediator mediator) =>
        {
            try
            {
                if (string.IsNullOrWhiteSpace(command.Email) || string.IsNullOrWhiteSpace(command.Password))
                    return Results.BadRequest("Email and password required.");
                
                var user = await mediator.SendCommandAsync<LoginCommand, ApplicationUser?>(command);

                if (user == null)
                {
                    return Results.Unauthorized();
                }
                
                await signInManager.SignInAsync(user, isPersistent: true);

                return Results.Ok();
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