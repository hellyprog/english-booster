using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace EnglishBooster.BusinessLogic
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

		public async Task StartReceiving(CancellationToken cancellationToken = default)
		{
			botClient.StartReceiving(cancellationToken: cancellationToken);

			var me = await botClient.GetMeAsync();
			Console.WriteLine($"{me.Username} is ready");
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

		private async void BotOnMessageReceived(object sender, MessageEventArgs e)
		{
			if (e.Message == null || e.Message.Type != MessageType.Text)
				return;

			Console.WriteLine(
				$"{e.Message.Chat.Title ?? e.Message.Chat.FirstName + " " + e.Message.Chat.LastName}({e.Message.From}) sent message"
			);

			var commandName = e.Message.Text.Split(' ').First();
			var commandFactory = new CommandFactory(botClient, e);
			var command = commandFactory.GetCommand(commandName);
			
			if (command != null)
			{
				await command.ExecuteAsync(); 
			}
		}
	}
}
