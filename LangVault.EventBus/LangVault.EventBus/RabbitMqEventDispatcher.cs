using Microsoft.Extensions.DependencyInjection;

namespace LangVault.EventBus;
public class RabbitMqEventDispatcher(IServiceProvider provider)
{
    private readonly IServiceProvider _provider = provider;

    public async Task DispatchAsync<TMessage, TConsumer>(TMessage message, CancellationToken cancellationToken = default)
        where TMessage : class
        where TConsumer : class, IConsumer<TMessage>
    {
        using var scope = _provider.CreateScope();
        var consumer = scope.ServiceProvider.GetRequiredService<TConsumer>();
        //consumer.Consume(message);
    }
}
