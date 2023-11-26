namespace Application.Common.Behaviors;
public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any()) return await next();
        var context = ValidationContext<TRequest>.CreateWithOptions(request, strategy => strategy.IncludeRulesNotInRuleSet());
        var validationResults = await Task.WhenAll(_validators.Select(x => x.ValidateAsync(context, cancellationToken)));
        var failures  = validationResults
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .ToList();
        if (failures.Count != 0) throw new Exceptions.ValidationException(failures);
        return await next();
    }
}
