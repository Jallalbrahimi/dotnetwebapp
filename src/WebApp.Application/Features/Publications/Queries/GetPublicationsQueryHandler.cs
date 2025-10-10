using WebApp.Application.Features.Publications.Dtos;
using WebApp.Application.Features.Publications.Interfaces;
using WebApp.Application.Mediator;

namespace WebApp.Application.Features.Publications.Queries;

public class GetPublicationsQueryHandler(IPublicationRepository publicationRepository): IQueryHandler<GetPublicationsQuery, IList<PublicationDto>>
{
    public async Task<IList<PublicationDto>> HandleAsync(GetPublicationsQuery query, CancellationToken cancellationToken)
    {
        var publications = await publicationRepository.GetPublicationsAsync(cancellationToken);
        return publications.Select(x => x.ToDto()).ToList();
    }
}