using WebApp.Application.Common;
using WebApp.Application.Features.Publications.Interfaces;
using WebApp.Application.Mediator;
using WebApp.Domain.Entities;


namespace WebApp.Application.Features.Publications.Commands;

public class DeletePublicationCommandHandler(IPublicationRepository publicationRepository)
    : ICommandHandler<DeletePublicationCommand, Unit>
{
    public async Task<Unit> HandleAsync(DeletePublicationCommand command, CancellationToken cancellationToken)
    {
        return await publicationRepository.DeletePublicationAsync(command.publicationId, cancellationToken).AsUnitTask();
    }
}