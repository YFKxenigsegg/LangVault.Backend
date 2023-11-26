using Application.Common.Behaviors;
using Application.Constructs;
using Application.Search;
using Application.Words;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        return services
            .AddMediatR(config => config.RegisterServicesFromAssembly(assembly))
            .AddTransient<IRequestHandler<SearchRequest<Word, WordInfo>, PaginatedList<WordInfo>>, SearchHandler<Word, WordInfo>>()
            .AddTransient<IRequestHandler<SearchRequest<Construct, ConstructInfo>, PaginatedList<ConstructInfo>>, SearchHandler<Construct, ConstructInfo>>()
            .AddValidatorsFromAssembly(assembly)
            .AddSingleton<IMapper>(new Mapper(new MapperConfiguration(config => config.AddMaps(assembly))))
            //.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>))
            //.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
            //.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>))
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>))
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}
