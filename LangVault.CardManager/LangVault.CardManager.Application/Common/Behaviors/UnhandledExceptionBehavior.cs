using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace LangVault.CardManager.Application.Common.Behaviors;
public class UnhandledExceptionBehavior<TRequest, TResponse>(ILogger<TRequest> logger)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<TRequest> _logger = logger;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;
            _logger.LogError(ex, "Request: Unhandled Excepton for request {Name} {Request}", requestName, JsonConvert.SerializeObject(request));
            throw;
        }
    }
}
