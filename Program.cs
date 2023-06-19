using Telegram.Bot;
using Telegram.Bot.Polling;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<BotBackgroundHostService>();
builder.Services.AddTransient<IUpdateHandler, UpdateHandler>();
builder.Services.AddHttpClient<OpenMeteoClient> (client =>
{
    client.BaseAddress = new Uri("https://api.open-meteo.com");
});
builder.Services.AddSingleton<ITelegramBotClient, TelegramBotClient>(
    p => new TelegramBotClient (builder.Configuration.GetValue("BotApiKey", string.Empty)));

builder.Build().Run();