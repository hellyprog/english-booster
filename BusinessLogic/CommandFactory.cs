using EnglishBooster.BusinessLogic.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace EnglishBooster.BusinessLogic
{
	public class CommandFactory
	{
		private readonly ITelegramBotClient telegramBotClient;
		private readonly EventArgs eventArgs;

		public CommandFactory(ITelegramBotClient telegramBotClient, EventArgs eventArgs)
		{
			this.telegramBotClient = telegramBotClient;
			this.eventArgs = eventArgs;
		}

		public ICommand GetCommand(string input)
		{
			return input switch
			{
				"/new_word" => new NewWordCommand(telegramBotClient, eventArgs as MessageEventArgs),
				"/recall" => new RecallCommand(telegramBotClient, eventArgs as MessageEventArgs),
				_ => null,
			};
		}
	}
}
