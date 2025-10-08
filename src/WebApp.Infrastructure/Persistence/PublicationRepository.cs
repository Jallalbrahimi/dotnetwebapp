using WebApp.Application.Features.Publications.Interfaces;
using WebApp.Domain.Entities;

namespace WebApp.Infrastructure.Persistence;

public class PublicationRepository : IPublicationRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PublicationRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> CreatePublicationAsync(Publication publication, CancellationToken cancellationToken)
    {
        _dbContext.Publications.Add(publication);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return publication.Id;
    }

    public Task<Publication> GetPublicationByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}