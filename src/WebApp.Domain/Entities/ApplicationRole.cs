using Microsoft.AspNetCore.Identity;

namespace WebApp.Domain.Entities;

public class ApplicationRole : IdentityRole<Guid>
{
    // Extended property
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    
    //Audit Columns
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset ModifiedOn { get; set; }
}