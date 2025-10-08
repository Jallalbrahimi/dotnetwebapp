using WebApp.Application.Features.Publications.Dtos;
using WebApp.Application.Features.Publications.Interfaces;
using WebApp.Application.Mediator;

namespace WebApp.Application.Features.Publications.Queries;

public class GetPublicationByIdQueryHandler(IPublicationRepository publicationRepository): IQueryHandler<GetPublicationByIdQuery, PublicationDto?>
{
    public async Task<PublicationDto?> HandleAsync(GetPublicationByIdQuery query, CancellationToken cancellationToken)
    {
        var user = await publicationRepository.GetPublicationByIdAsync(query.PublicationId, cancellationToken);
        return user?.ToDto();
    }
}