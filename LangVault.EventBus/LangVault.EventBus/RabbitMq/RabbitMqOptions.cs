namespace LangVault.EventBus.RabbitMq;
public class RabbitMqOptions
{
    public string Host { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
    public ushort? Port { get; set; }
}
