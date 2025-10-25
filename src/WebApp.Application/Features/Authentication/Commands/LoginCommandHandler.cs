using WebApp.Application.Features.Authentication.Interfaces;
using WebApp.Application.Features.Publications.Commands;
using WebApp.Application.Mediator;
using WebApp.Domain.Entities;

namespace WebApp.Application.Features.Authentication.Commands;

public class LoginCommandHandler(IAuthenticationService authenticationService)   
    : ICommandHandler<LoginCommand, ApplicationUser?>
{
    public async Task<ApplicationUser?> HandleAsync(LoginCommand command, CancellationToken cancellationToken)
    {
        return await authenticationService.AuthenticateAsync(command.Email, command.Password);
    }
}