using WebApp.Domain.Entities;

namespace WebApp.Application.Features.Publications.Dtos;

public static class PublicationExtensions
{
    public static PublicationDto ToDto(this Publication publication) => new()
    {
        Id = publication.Id,
        Title = publication.Title,
        Body = publication.Body,
        PublishedAt = publication.PublishedAt,
    };
}