﻿using Application.Common.Interfaces;
using Infrastructure.Interfaces;

namespace Application.Common.Behaviors;
public class AuthorizationBehaviour<TRequest, TResponse>(ICurrentUserProvider currentUserProvider, IIdentityService identityService)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull

{
    private readonly ICurrentUserProvider _currentUserProvider = currentUserProvider;
    private readonly IIdentityService _identityService = identityService;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        return await next();
    }
}
