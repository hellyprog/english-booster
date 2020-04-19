using EnglishBooster.BusinessLogic;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;

namespace EnglishBooster
{
    class Program
    {
        static async Task Main(string[] args)
        {
            /*var cts = new CancellationTokenSource();
            var botController = new BotController();
            await botController.StartReceiving(cts.Token);
            
            Thread.Sleep(int.MaxValue);

            cts.Cancel();*/

            var client = new TelegramBotClient("1123299534:AAEjQzvubh4Cwznmnq1M6dmYHTSJ44Xn9YU");
            client.SetWebhookAsync("https://1280287d.ngrok.io/bot").Wait();
            Console.ReadLine();
        }
    }
}
