namespace WebApp.Domain.Entities;

public abstract class BaseEntity
{
    // EF Core primary key
    public Guid Id { get; init; } = Guid.NewGuid();

    // Timestamps
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    // Soft delete support
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }

}