using Telegram.Bot;

namespace LangVault.Notifications;
public class TelegramSender(IConfiguration configuration) : ISender
{
    private readonly IConfiguration _configuration = configuration;
    private TelegramBotClient _bot;

    public async Task<TelegramBotClient> GetBot()
    {
        if(_bot != null) return _bot;
        _bot = new TelegramBotClient(_configuration["Telegram.Token"]);
        var hook = $"{_configuration["Telegram.Url"]}/api/??";
        await _bot.SetWebhookAsync(hook);
        return _bot;
    }

    public async Task SendAsync()
    {
        var bot = await GetBot(); 
    }
}
