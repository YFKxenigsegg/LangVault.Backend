namespace LangVault.EventBus.RabbitMq;
public sealed class RabbitMqEventBus(IPublishEndpoint publishEndpoint) : IEventBus
{
    private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

    public Task PublishAsync<TMessage>(TMessage message, CancellationToken cancellationToken = default)
        where TMessage : class =>
        _publishEndpoint.Publish(message, cancellationToken);
}
