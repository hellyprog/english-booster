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
            var cts = new CancellationTokenSource();
            var botController = new BotController();
            await botController.StartReceiving(cts.Token);
            Console.ReadKey();

            cts.Cancel();
        }
    }
}
