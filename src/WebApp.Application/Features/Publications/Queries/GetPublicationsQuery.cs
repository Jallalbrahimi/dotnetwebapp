using WebApp.Application.Features.Publications.Dtos;
using WebApp.Application.Mediator;

namespace WebApp.Application.Features.Publications.Queries;

public record GetPublicationsQuery : IQuery<IList<PublicationDto>>;
