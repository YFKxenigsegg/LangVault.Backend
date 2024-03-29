﻿using LangVault.CardManager.Application.Common.Behaviors;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LangVault.CardManager.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        return services
            .AddMediatR(config => config.RegisterServicesFromAssembly(assembly))
            //.AddTransient<IRequestHandler<SearchRequest<Word, WordInfo>, PaginatedList<WordInfo>>, SearchHandler<Word, WordInfo>>()
            //.AddTransient<IRequestHandler<SearchRequest<Construct, EditorialCardInfo>, PaginatedList<EditorialCardInfo>>, SearchHandler<Construct, EditorialCardInfo>>()
            .AddValidatorsFromAssembly(assembly)
            .AddSingleton<IMapper>(new Mapper(new MapperConfiguration(config => config.AddMaps(assembly))))
            //.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>))
            //.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
            //.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>))
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>))
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}
