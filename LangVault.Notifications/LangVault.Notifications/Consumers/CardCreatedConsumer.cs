using LangVault.EventBus.Events.Card;
using LangVault.Notifications;

namespace LangVault.Notifications.Consumers;
public class CardCreatedConsumer(ISender sender) : IConsumer<CardCreated>
{
    private readonly ISender _sender = sender;

    public async Task Consume(ConsumeContext<CardCreated> context)
    {
        await _sender.SendAsync();
    }
}