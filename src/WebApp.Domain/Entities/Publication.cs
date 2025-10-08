using WebApp.Domain.Entities;

namespace WebApp.Domain.Entities;

public class Publication : BaseEntity
{
    public required string Title { get; init; }
    public required string Body { get; init; }
    
    public required DateTime PublishedAt { get; init; }
}