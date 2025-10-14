using WebApp.Application.Common;
using WebApp.Application.Features.Publications.Interfaces;
using WebApp.Application.Mediator;
using WebApp.Domain.Entities;

namespace WebApp.Application.Features.Publications.Commands;

public class UpdatePublicationCommandHandler(IPublicationRepository publicationRepository)
    : ICommandHandler<UpdatePublicationCommand, Unit>
{
    public async Task<Unit> HandleAsync(UpdatePublicationCommand command, CancellationToken cancellationToken)
    {
        // Update domain object
        // TODO: validate input
        Publication publication = new () { Id = command.Id, Title = command.Title, Body = command.Body, PublishedAt = command.PublishedAt};

        // Update publication
        return await publicationRepository.UpdatePublicationAsync(publication, cancellationToken).AsUnitTask();
    }
}