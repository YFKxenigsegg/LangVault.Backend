namespace LangVault.EventBus;
public interface IEventBus
{
    Task PublishAsync<TMessage>(TMessage message, CancellationToken cancellationToken = default)
        where TMessage : class;
    //Task Subscribe<TMessage>(string subscriptionId, Func<TMessage, Task> onMessage);
}
