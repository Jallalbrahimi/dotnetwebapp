using WebApp.Application.Features.Publications.Dtos;
using WebApp.Application.Mediator;

namespace WebApp.Application.Features.Publications.Commands;

public record CreatePublicationCommand(string Title, string Body, DateTime Published) : ICommand<PublicationDto>;
