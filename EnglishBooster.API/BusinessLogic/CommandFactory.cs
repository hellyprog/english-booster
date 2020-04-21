using EnglishBooster.API.BusinessLogic.Commands;
using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace EnglishBooster.API.BusinessLogic
{
	public class CommandFactory
	{
		private readonly ITelegramBotClient telegramBotClient;
		private readonly Update update;

		public CommandFactory(ITelegramBotClient telegramBotClient, Update update)
		{
			this.telegramBotClient = telegramBotClient;
			this.update = update;
		}

		public ICommand GetCommand(string input)
		{
			return input switch
			{
				"/new_word" => new NewWordCommand(telegramBotClient, update.Message),
				"/recall" => new RecallCommand(telegramBotClient, update.Message),
				_ => null,
			};
		}
	}
}
