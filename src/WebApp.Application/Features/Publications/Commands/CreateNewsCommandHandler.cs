using WebApp.Application.Features.Publications.Dtos;
using WebApp.Application.Features.Publications.Interfaces;
using WebApp.Application.Mediator;
using WebApp.Domain.Entities;


namespace WebApp.Application.Features.Publications.Commands;

public class CreateNewsCommandHandler(IPublicationRepository publicationRepository)
    : ICommandHandler<CreatePublicationCommand, PublicationDto>
{
    public async Task<PublicationDto> HandleAsync(CreatePublicationCommand command, CancellationToken cancellationToken)
    {
        // Create domain object
        //TODO: mock the Now
        Publication publication = new () { Title = command.Title, Body = command.Body, PublishedAt = command.Published};

        // Create and return DTO from saved domain object
        var createdPublication = await publicationRepository.CreatePublicationAsync(publication, cancellationToken);
        return publication.ToDto();
    }
}