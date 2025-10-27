using Microsoft.AspNetCore.Identity;

namespace WebApp.Identity.Entities;

/// <summary>
/// Inheriting from IdentityUser forces the Domain project to rely on Microsoft.AspNetCore.Identity namespace.
/// From a purely theoretical point of view, you'd want - as much as possible - to avoid referring another assembly in the Domain model
/// However, this appear to be an acceptable trade-off for a small application without an Auth server.
/// If the need to have something more solid arise, a refactoring 
/// </summary>
public class ApplicationUser : IdentityUser<Guid>
{
    // Extended properties
    public string? FirstName { get; set; } = null!;
    public string? LastName { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }
    public DateTimeOffset LastLogin { get; set; }
    public bool IsActive { get; set; }
    
    //Audit Columns
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset ModifiedOn { get; set; }
}
