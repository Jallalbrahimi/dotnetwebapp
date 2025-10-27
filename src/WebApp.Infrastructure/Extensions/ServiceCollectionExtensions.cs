using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Application.Common.Logging;
using WebApp.Application.Features.Publications.Interfaces;
using WebApp.Application.Mediator;
using WebApp.Infrastructure.Persistence;

namespace WebApp.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        // Mediator
        // Has to be scoped because the current mediator implementation does not manage scopes.
        services.AddScoped<IMediator, Mediator>();
        services.AddSingleton(TimeProvider.System);
        
        // Register handlers
        services.RegisterHandlers(typeof(IQueryHandler<,>),  typeof(IQueryHandler<,>).Assembly);
        services.RegisterHandlers(typeof(ICommandHandler<,>),  typeof(ICommandHandler<,>).Assembly);
        
#if DEBUG
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
#endif
        
        // Register the repositories
        services.AddScoped<IPublicationRepository, PublicationRepository>();
        
        
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(connectionString));
        
        return services;
    }

    private static void RegisterHandlers(this IServiceCollection services, Type handlerInterface, Assembly assembly)
    {
        if (!handlerInterface.IsInterface)
        {
            throw new ApplicationException("handlerInterface must be an interface");
        }
        
        var implementations = assembly.GetTypes()
            .Where(type => !type.IsAbstract && !type.IsInterface)
            .Where(type => type.GetInterfaces()
                .Any(i => i.IsGenericType &&
                          i.GetGenericTypeDefinition() == handlerInterface));

        foreach (var implementation in implementations)
        {
            var interfaceType = implementation.GetInterfaces()
                .First(i => i.IsGenericType &&
                            i.GetGenericTypeDefinition() == handlerInterface);

            services.AddTransient(interfaceType, implementation);
        }
    }
}