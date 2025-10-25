using WebApp.Application.Mediator;

namespace WebApp.Application.Features.Publications.Commands;

public record CreatePublicationCommand(string Title, string Body, DateTimeOffset PublishedAt) : ICommand<Guid>;
