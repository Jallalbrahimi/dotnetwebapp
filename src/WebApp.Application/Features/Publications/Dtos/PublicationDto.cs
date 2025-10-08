namespace WebApp.Application.Features.Publications.Dtos;

public class PublicationDto
{
    public required Guid Id { get; set; }
    public required string Title { get; init; }
    public required string Body { get; init; }
    public required DateTime PublishedAt { get; init; }
}