﻿using EnglishBooster.API.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace EnglishBooster.API.BusinessLogic.Commands
{
	public class MessageCommand : ICommand
	{
		private readonly ITelegramBotClient telegramBotClient;
		private readonly Message message;
		private readonly IWordService messageService;

		public MessageCommand(ITelegramBotClient telegramBotClient, Message message, IWordService messageService)
		{
			this.telegramBotClient = telegramBotClient;
			this.message = message;
			this.messageService = messageService;
		}

		public Task ExecuteAsync()
		{
			var commandName = message.Text.Split(' ').First();

			return commandName switch
			{
				"/new_word" => messageService.SendNewWordAsync(telegramBotClient, message),
				"/recall" => messageService.SendWordForRecallAsync(telegramBotClient, message),
				_ => null,
			};
		}
	}
}
