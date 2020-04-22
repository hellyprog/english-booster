using EnglishBooster.API.BusinessLogic.Commands;
using EnglishBooster.API.BusinessLogic.Factories;
using System;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace EnglishBooster.API.BusinessLogic.Factories
{
	public class MessageCommandFactory : ICommandFactory
	{
		private readonly ITelegramBotClient telegramBotClient;
		private readonly Update update;

		public MessageCommandFactory(ITelegramBotClient telegramBotClient, Update update)
		{
			this.telegramBotClient = telegramBotClient;
			this.update = update;
		}

		public ICommand GetCommand() => GetCommand(telegramBotClient, update);

		private ICommand GetCommand(ITelegramBotClient telegramBotClient, Update update)
		{
            var commandName = update.Message.Text.Split(' ').First();

			return commandName switch
			{
				"/new_word" => new NewWordCommand(telegramBotClient, update.Message),
				"/recall" => new RecallCommand(telegramBotClient, update.Message),
				_ => null,
			};
		}
	}
}
