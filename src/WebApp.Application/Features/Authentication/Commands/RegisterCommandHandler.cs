using WebApp.Application.Features.Authentication.Interfaces;
using WebApp.Application.Mediator;
using WebApp.Domain.Entities;

namespace WebApp.Application.Features.Authentication.Commands;

public class RegisterCommandHandler(IAuthenticationService authenticationService)   
    : ICommandHandler<RegisterCommand, bool>
{
    public async Task<bool> HandleAsync(RegisterCommand command, CancellationToken cancellationToken)
    {
        var user = new ApplicationUser() {UserName = command.Name, Email = command.Email, LastName = command.LastName, FirstName = command.FirstName};
        return await authenticationService.RegisterAsync(user, command.Password);
    }
}
