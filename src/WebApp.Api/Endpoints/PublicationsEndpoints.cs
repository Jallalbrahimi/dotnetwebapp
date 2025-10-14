using Microsoft.AspNetCore.Mvc;
using WebApp.Application.Common;
using WebApp.Application.Features.Publications.Commands;
using WebApp.Application.Features.Publications.Dtos;
using WebApp.Application.Features.Publications.Queries;
using WebApp.Application.Mediator;

namespace WebApp.Api.Endpoints;

public static class PublicationsEndpoints
{
    public static void MapPublicationsEndpoints(this IEndpointRouteBuilder app)
    {
        // POST: /api/publications
        app.MapPost("/api/publications", async (CreatePublicationCommand command, [FromServices] IMediator mediator, CancellationToken cancellationToken) =>
        {
            var publicationId = await mediator.SendCommandAsync<CreatePublicationCommand, Guid>(new CreatePublicationCommand(command.Title, command.Body, command.PublishedAt), cancellationToken);
            return Results.Created($"/api/publications/{publicationId}", publicationId);
        });

        // GET: /api/publications/
        app.MapGet("/api/publications", async ([FromServices] IMediator mediator, CancellationToken cancellationToken) =>
        {
            var publications = await mediator.SendQueryAsync<GetPublicationsQuery, IList<PublicationDto>>(new GetPublicationsQuery(), cancellationToken);
            return Results.Ok(publications);
        });
        
        // GET: /api/publications/id
        app.MapGet("/api/publications/{id:guid}", async (Guid id, [FromServices] IMediator mediator, CancellationToken cancellationToken) =>
        {
            var publication = await mediator.SendQueryAsync<GetPublicationByIdQuery, PublicationDto?>(new GetPublicationByIdQuery(id), cancellationToken);
            return Results.Ok(publication);
        });
        
        // PUT: /api/publications/
        app.MapPut("/api/publications/", async (UpdatePublicationCommand command, [FromServices] IMediator mediator, CancellationToken cancellationToken) =>
        {
            await mediator.SendCommandAsync<UpdatePublicationCommand, Unit>(new UpdatePublicationCommand(command.Id, command.Title, command.Body, command.PublishedAt), cancellationToken);
            return Results.NoContent();
        });
        
        // DELETE: /api/publications/id
        app.MapDelete("/api/publications/{id:guid}", async (Guid id, [FromServices] IMediator mediator, CancellationToken cancellationToken) =>
        {
            await mediator.SendCommandAsync<DeletePublicationCommand, Unit>(new DeletePublicationCommand(id), cancellationToken);
            return Results.NoContent();
        });
    }
}