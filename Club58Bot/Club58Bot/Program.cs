using Club58_Bot;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

internal class Program
{
    static ITelegramBotClient bot = new TelegramBotClient("6924859504:AAEyep5De2g_IZ3mhOJ4Buh03XfB2DcPkJg");

    public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        // Некоторые действия
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
        if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
        {
            var message = update.Message;
            if (message.Text.ToLower() == "/start")
            {
                await botClient.SendTextMessageAsync(message.Chat, "Добро пожаловать на борт, добрый путник!");
                return;
            }

            if (message.Text.ToLower() == "/events")
            {
                var service = new MockClubEventService();
                var events = service.GetEvents();
                var eventNames = string.Join(", ", events.Select(e => e.Name));
                await botClient.SendTextMessageAsync(message.Chat, $"События: {eventNames}");
                return;
            }

            await botClient.SendTextMessageAsync(message.Chat, "Привет-привет!!");
        }
    }

    public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception,
        CancellationToken cancellationToken)
    {
        // Некоторые действия
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

        var cts = new CancellationTokenSource();
        var cancellationToken = cts.Token;
        var receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = { }, // receive all update types
        };
        bot.StartReceiving(
            HandleUpdateAsync,
            HandleErrorAsync,
            receiverOptions,
            cancellationToken
        );
        Console.ReadLine();
    }
}