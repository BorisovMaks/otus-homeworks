using Microsoft.Extensions.Configuration;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Homework7
{
    internal class Program
    {
        private static readonly string _token = "SecretKey";

        static async Task Main()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();

            var token = config.GetValue<string>(_token);

            if (token == null)
            {
                Console.WriteLine("Запуск невозможен");
                return;
            }

            var handler = new UpdateHandler();

            try
            {
                using var cts = new CancellationTokenSource();
                var botClient = new TelegramBotClient(token);

                var receiverOptions = new ReceiverOptions
                {
                    AllowedUpdates = [UpdateType.Message],
                    DropPendingUpdates = true
                };

                Subscribe(handler);

                botClient.StartReceiving(handler, receiverOptions, cts.Token);

                var me = await botClient.GetMe(cts.Token);
                Console.WriteLine($"{me.FirstName} запущен!");

                while (true)
                {
                    Console.WriteLine("Нажмите клавишу 'A' для выхода");

                    if (Console.ReadKey().Key == ConsoleKey.A)
                    {
                        cts.Cancel();
                        break;
                    }
                    else
                    {
                        StringBuilder sb = new();
                        sb.Append($"FirstName: {me.FirstName}\n");
                        sb.Append($"LastName: {me.LastName}\n");
                        sb.Append($"Username: {me.Username}\n");
                        sb.Append($"Id: {me.Id.ToString()}\n");
                        Console.WriteLine(sb.ToString());
                    }
                }
            }
            finally
            {
                Unsubscribe(handler);
            }
        }

        private static void Unsubscribe(UpdateHandler handler)
        {
            handler.OnHandleUpdateStarted -= StartHandleMessage;
            handler.OnHandleUpdateCompleted -= StartHandleMessage;
        }

        private static void Subscribe(UpdateHandler handler)
        {
            handler.OnHandleUpdateStarted += StartHandleMessage;
            handler.OnHandleUpdateCompleted += CompleteHandleMessage;
        }

        private static void StartHandleMessage(Message? message)
        {
            Console.WriteLine($"Началась обработка сообщения '{message?.Text}'");
        }

        private static void CompleteHandleMessage(Message? message)
        {
            Console.WriteLine($"Закончилась обработка сообщения '{message?.Text}'");
        }
    }
}
