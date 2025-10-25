using WebApp.Application.Mediator;

namespace WebApp.Application.Features.Authentication.Commands;

public record RegisterCommand(string Name, string FirstName, string LastName, string Email, string Password) : ICommand<bool>;