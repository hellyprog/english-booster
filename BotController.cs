using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace EnglishBooster
{
	public class BotController
	{
		private ITelegramBotClient botClient;

		public BotController()
		{
			this.botClient = new TelegramBotClient("1123299534:AAEjQzvubh4Cwznmnq1M6dmYHTSJ44Xn9YU");

			botClient.OnMessage += BotOnMessageReceived;
			botClient.OnMessageEdited += BotOnMessageReceived;
			botClient.OnCallbackQuery += BotOnCallbackQueryReceived;
			botClient.OnInlineQuery += BotOnInlineQueryReceived;
			botClient.OnInlineResultChosen += BotOnChosenInlineResultReceived;
			botClient.OnReceiveError += BotOnReceiveError;
		}

		private void BotOnReceiveError(object sender, ReceiveErrorEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void BotOnChosenInlineResultReceived(object sender, ChosenInlineResultEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void BotOnInlineQueryReceived(object sender, InlineQueryEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void BotOnCallbackQueryReceived(object sender, CallbackQueryEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void BotOnMessageReceived(object sender, MessageEventArgs e)
		{
			throw new NotImplementedException();
		}

		public async Task StartReceiving(CancellationToken cancellationToken = default)
		{
			botClient.StartReceiving(cancellationToken: cancellationToken);

			var me = await botClient.GetMeAsync();
			Console.WriteLine($"{me.Username} is ready");
		}
	}
}
