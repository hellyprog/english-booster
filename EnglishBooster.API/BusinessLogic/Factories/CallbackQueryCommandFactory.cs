using EnglishBooster.API.BusinessLogic.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace EnglishBooster.API.BusinessLogic.Factories
{
	public class CallbackQueryCommandFactory : ICommandFactory
	{
		private readonly ITelegramBotClient telegramBotClient;
		private readonly Update update;

		public CallbackQueryCommandFactory(ITelegramBotClient telegramBotClient, Update update)
		{
			this.telegramBotClient = telegramBotClient;
			this.update = update;
		}

		public ICommand GetCommand() => new CheckRecallAnswerCommand(telegramBotClient, update.CallbackQuery);
	}
}
