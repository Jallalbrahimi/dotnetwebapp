using Microsoft.Extensions.Logging;
using WebApp.Application.Mediator;

namespace WebApp.Application.Common.Logging;

public class LoggingBehavior<TInput, TOutput>(ILogger<LoggingBehavior<TInput, TOutput>> logger)
    : IPipelineBehavior<TInput, TOutput>
{
    public async Task<TOutput> HandleAsync(TInput input, Func<Task<TOutput>> next, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Starting: {typeof(TInput).Name}");
        var result = await next();
        logger.LogInformation($"Finished: {typeof(TOutput).Name}");
        return result;
    }
}