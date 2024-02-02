//using LangVault.EventBus.Events.Management;
//using MassTransit;

//public class CardCreatedEventConsumer(ILogger<CardCreatedEventConsumer> logger) : IConsumer<CardCreatedEvent>
//{
//    private readonly ILogger<CardCreatedEventConsumer> _logger = logger;

//    public Task Consume(ConsumeContext<CardCreatedEvent> context)
//    {
//        _logger.LogInformation($"{context.Message}");
//        return Task.CompletedTask;
//    }
//}