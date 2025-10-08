using WebApp.Domain.Entities;

namespace WebApp.Application.Features.Publications.Interfaces;

public interface IPublicationRepository
{
    Task<Guid> CreatePublicationAsync(Publication publication, CancellationToken cancellationToken);
    
    Task<Publication> GetPublicationByIdAsync(Guid id, CancellationToken cancellationToken);
}