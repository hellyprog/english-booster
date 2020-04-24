using EnglishBooster.API.BusinessLogic.Commands;
using EnglishBooster.API.BusinessLogic.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace EnglishBooster.API.BusinessLogic
{
	public class FactoryDecider
	{
		public ICommandFactory GetFactory(ITelegramBotClient telegramBotClient, Update update)
		{
			return update.Type switch
			{
				UpdateType.Message => new MessageCommandFactory(telegramBotClient, update),
				UpdateType.CallbackQuery => new CallbackQueryCommandFactory(telegramBotClient, update),
				_ => null
			};
		}
	}
}
