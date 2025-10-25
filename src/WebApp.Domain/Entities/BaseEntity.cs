namespace WebApp.Domain.Entities;

public abstract class BaseEntity
{
    // EF Core primary key
    public Guid Id { get; init; } = Guid.NewGuid();

   
    // Soft delete support
    public bool IsDeleted { get; set; }
    
    // Audit
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset DeletedOn { get; set; }

}