using WebApp.Application.Common;
using WebApp.Application.Mediator;

namespace WebApp.Application.Features.Publications.Commands;

public record UpdatePublicationCommand(Guid Id, string Title, string Body, DateTime PublishedAt) : ICommand<Unit>;