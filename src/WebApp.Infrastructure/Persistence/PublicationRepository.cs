using Microsoft.EntityFrameworkCore;
using WebApp.Application.Features.Publications.Interfaces;
using WebApp.Domain.Entities;

namespace WebApp.Infrastructure.Persistence;

public class PublicationRepository(ApplicationDbContext dbContext, TimeProvider timeProvider) : IPublicationRepository
{
    public async Task<Guid> CreatePublicationAsync(Publication publication, CancellationToken cancellationToken)
    {
        publication.CreatedOn = timeProvider.GetUtcNow();
        dbContext.Publications.Add(publication);
        await dbContext.SaveChangesAsync(cancellationToken);
        return publication.Id;
    }

    public async Task<IList<Publication>> GetPublicationsAsync(CancellationToken cancellationToken)
    {
        return await dbContext.Publications.Where(p => !p.IsDeleted).ToListAsync(cancellationToken: cancellationToken);
    }
    
    public async Task<Publication?> GetPublicationByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.Publications.Where(p => p.Id == id && !p.IsDeleted).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task DeletePublicationAsync(Guid id, CancellationToken cancellationToken)
    {
        var publication = await dbContext.Publications.FindAsync(id, cancellationToken);
        if (publication == null) return;
        publication.IsDeleted = true;
        publication.DeletedOn = timeProvider.GetUtcNow();
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdatePublicationAsync(Publication publication, CancellationToken cancellationToken)
    {
        var currentPublication = await GetPublicationByIdAsync(publication.Id, cancellationToken);
        if (currentPublication == null) throw new ApplicationException("Publication not found");
        
        currentPublication.Title = publication.Title;
        currentPublication.Body = publication.Body;
        currentPublication.PublishedAt = publication.PublishedAt;
        
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}