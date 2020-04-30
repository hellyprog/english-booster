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
			var replyTo = $"{callbackQuery.From.FirstName} {callbackQuery.From.LastName}";
			var isCorrectAnswer = bool.Parse(callbackQuery.Data);

			await telegramBotClient.AnswerCallbackQueryAsync(
				callbackQueryId: callbackQuery.Id,
				text: isCorrectAnswer ? "You're right" : "Try again"
			);

			await telegramBotClient.SendTextMessageAsync(
				chatId: callbackQuery.Message.Chat.Id,
				text: $"{replyTo} - {(isCorrectAnswer ? "You're right" : "Try again")}"
			);
		}
	}
}
