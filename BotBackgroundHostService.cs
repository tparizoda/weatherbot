using Telegram.Bot;
using Telegram.Bot.Polling;

public class BotBackgroundHostService : BackgroundService
{
    private readonly ILogger <BotBackgroundHostService> logger;
    private readonly ITelegramBotClient telegramBotClient;
    private readonly IUpdateHandler updateHandler;

    public BotBackgroundHostService(ILogger<BotBackgroundHostService> logger,
    ITelegramBotClient telegramBotClient, IUpdateHandler updateHandler)
    {
        this.logger = logger;
        this.telegramBotClient = telegramBotClient;
        this.updateHandler = updateHandler;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var me = await telegramBotClient.GetMeAsync(stoppingToken);
        logger.LogInformation("Bot started {username}", me.Username);

        telegramBotClient.StartReceiving(
            updateHandler : updateHandler,
            receiverOptions : new Telegram.Bot.Polling.ReceiverOptions(),
            cancellationToken : stoppingToken);
    }
}