using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace EnglishBooster.API.BusinessLogic.Commands
{
	public class CheckRecallAnswerCommand : ICommand
	{
		private readonly ITelegramBotClient telegramBotClient;
		private readonly CallbackQuery callbackQuery;

		public CheckRecallAnswerCommand(ITelegramBotClient telegramBotClient, CallbackQuery callbackQuery)
		{
			this.telegramBotClient = telegramBotClient;
			this.callbackQuery = callbackQuery;
		}

		public async Task ExecuteAsync()
		{
			await telegramBotClient.SendTextMessageAsync(
					callbackQuery.Message.Chat.Id,
					"Callback query"
				);
		}
	}
}
