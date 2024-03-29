﻿using LangVault.CardManager.Application.Common.Interfaces;
using LangVault.CardManager.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace LangVault.CardManager.Application.Common.Behaviors;
public class PerformanceBehavior<TRequest, TReponse>(ILogger<TRequest> logger, ICurrentUserProvider currentUserProvider, IIdentityService identityService)
    : IPipelineBehavior<TRequest, TReponse> where TRequest : notnull
{
    private readonly Stopwatch _times = new();
    private readonly ILogger<TRequest> _logger = logger;
    private readonly ICurrentUserProvider _currentUserProvider = currentUserProvider;
    private readonly IIdentityService _identityService = identityService;

    public async Task<TReponse> Handle(TRequest request, RequestHandlerDelegate<TReponse> next, CancellationToken cancellationToken)
    {
        return await next();
    }
}
