using System;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace english_booster
{
    class Program
    {
        static ITelegramBotClient botClient;

        static void Main(string[] args)
        {
            botClient = new TelegramBotClient("1123299534:AAHSRtGaVSA626roRY5DiuP9FU2XXno-CzI");
            var me = botClient.GetMeAsync().Result;
            Console.WriteLine(
              $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
            );

            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            Thread.Sleep(int.MaxValue);
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");

                var message = e.Message.Text == "йойки"
                    ? "\u2764"
                    : "You said:\n" + e.Message.Text;

                await botClient.SendTextMessageAsync(
                  chatId: e.Message.Chat,
                  text: message
                );
            }
        }
    }
}
