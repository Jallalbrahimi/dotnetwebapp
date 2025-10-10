using WebApp.Application.Common;
using WebApp.Application.Mediator;

namespace WebApp.Application.Features.Publications.Commands;

public record DeletePublicationCommand (Guid publicationId) : ICommand<Unit>;