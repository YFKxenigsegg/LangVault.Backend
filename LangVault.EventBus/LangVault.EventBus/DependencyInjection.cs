using LangVault.EventBus.RabbitMq;
using LangVault.Shared.Web;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LangVault.EventBus;
public static class DependencyInjection
{
    public static IServiceCollection AddMassTransit(this IServiceCollection services, Assembly assembly)
    {
        services.AddValidateOptions<RabbitMqOptions>();
        services.AddMassTransit(configure => SetupMassTransitConfig(services, configure, assembly));
        services.AddScoped<IEventBus, RabbitMqEventBus>();
        return services;
    }

    private static void SetupMassTransitConfig(IServiceCollection services, IBusRegistrationConfigurator configure, Assembly assembly)
    {
        configure.AddConsumers(assembly);
        configure.AddSagaStateMachines(assembly);
        configure.AddSagas(assembly);
        configure.AddActivities(assembly);
        configure.UsingRabbitMq((context, configurator) =>
        {
            var options = services.GetOptions<RabbitMqOptions>(nameof(RabbitMqOptions));
            configurator.Host(options?.Host, options?.Port ?? 5672, "/", h =>
            {
                h.Username(options?.UserName);
                h.Password(options?.Password);
            });
            configurator.ConfigureEndpoints(context);
            configurator.UseMessageRetry(AddRetryConfiguration);
        });
    }

    private static void AddRetryConfiguration(IRetryConfigurator retryConfigurator)
    {
        retryConfigurator.Exponential(
            3,
            TimeSpan.FromMicroseconds(200),
            TimeSpan.FromMinutes(120),
            TimeSpan.FromMilliseconds(200));
        //.Ignore<ValidationException>();
    }
}
