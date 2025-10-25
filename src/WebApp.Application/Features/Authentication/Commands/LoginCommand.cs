using WebApp.Application.Mediator;
using WebApp.Domain.Entities;

namespace WebApp.Application.Features.Authentication.Commands;


public record LoginCommand(string Email, string Password, bool RememberMe = false) : ICommand<ApplicationUser?>;
