using Application.Common.Interfaces;
using Infrastructure.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Application.Common.Behaviors;
public class LoggingBehavior<TRequest, TResponse>(ILogger<TRequest> logger, ICurrentUserProvider currentUserProvider, IIdentityService identityService)
    : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger _logger = logger;
    private readonly ICurrentUserProvider _currentUserProvider = currentUserProvider;
    private readonly IIdentityService _identityService = identityService;

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var userId = _currentUserProvider.UserId ?? string.Empty;
        var userName = string.Empty;
        if(!string.IsNullOrEmpty(userId))
        {
            userName = await _identityService.GetUserNameAsync(userId);
        }
        _logger.LogDebug($"Request {requestName} {userId} {userName} {JsonConvert.SerializeObject(request)}");
    }
}
