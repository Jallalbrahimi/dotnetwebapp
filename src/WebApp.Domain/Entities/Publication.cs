using WebApp.Domain.Entities;

namespace WebApp.Domain.Entities;

public class Publication : BaseEntity
{
    public required string Title { get; set; }
    public required string Body { get; set; }
    public required DateTime PublishedAt { get; set; }
}