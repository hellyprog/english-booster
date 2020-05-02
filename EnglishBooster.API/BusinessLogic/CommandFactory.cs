using EnglishBooster.API.BusinessLogic.Commands;
using EnglishBooster.API.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace EnglishBooster.API.BusinessLogic
{
	public class CommandFactory : ICommandFactory
	{
		private readonly ITelegramBotClient telegramBotClient;
		private readonly IMessageService messageService;

		public CommandFactory(ITelegramBotClient telegramBotClient, IMessageService messageService)
		{
			this.telegramBotClient = telegramBotClient;
			this.messageService = messageService;
		}

		public ICommand GetCommand(Update update)
		{
			return update.Type switch
			{
				UpdateType.Message => new MessageCommand(telegramBotClient, update.Message, messageService),
				UpdateType.CallbackQuery => new CheckRecallAnswerCommand(telegramBotClient, update.CallbackQuery),
				_ => null
			};
		}
	}
}
