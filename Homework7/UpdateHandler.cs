using System.Net.Http.Json;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Homework7
{
    internal class UpdateHandler : IUpdateHandler
    {
        public delegate void MessageHandler(Message? message);
        public event MessageHandler? OnHandleUpdateStarted;
        public event MessageHandler? OnHandleUpdateCompleted;

        public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, HandleErrorSource source, CancellationToken cancellationToken)
        {
            Console.WriteLine(exception.Message);
            return Task.CompletedTask;
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type == UpdateType.Message)
            {
                OnHandleUpdateStarted?.Invoke(update.Message);

                if (update.Message?.Text?.ToLower() == "/cat")
                {
                    using var client = new HttpClient();
                    var catFact = await client.GetFromJsonAsync<CatFact>("https://catfact.ninja/fact", cancellationToken);

                    if (catFact == null)
                    {
                        OnHandleUpdateCompleted?.Invoke(new Message()
                        {
                            Text = "Не удалось получить данные"
                        });

                        return;
                    }

                    await botClient.SendMessage(update.Message.Chat.Id, text: catFact.Fact, cancellationToken: cancellationToken);
                    OnHandleUpdateCompleted?.Invoke(update.Message);
                    return;
                }

                await botClient.SendMessage(
                    update.Message.Chat.Id,
                    "Сообщение успешно принято",
                    cancellationToken: cancellationToken);

                OnHandleUpdateCompleted?.Invoke(update.Message);
            }
        }
    }
}
