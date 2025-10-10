using WebApp.Application.Features.Publications.Interfaces;
using WebApp.Application.Mediator;
using WebApp.Domain.Entities;


namespace WebApp.Application.Features.Publications.Commands;

public class CreatePublicationCommandHandler(IPublicationRepository publicationRepository)
    : ICommandHandler<CreatePublicationCommand, Guid>
{
    public async Task<Guid> HandleAsync(CreatePublicationCommand command, CancellationToken cancellationToken)
    {
        // Create domain object
        //TODO: mock the Now
        Publication publication = new () { Title = command.Title, Body = command.Body, PublishedAt = command.PublishedAt};

        // Create and return DTO from saved domain object
        var createdPublicationId = await publicationRepository.CreatePublicationAsync(publication, cancellationToken);
        return createdPublicationId;
    }
}