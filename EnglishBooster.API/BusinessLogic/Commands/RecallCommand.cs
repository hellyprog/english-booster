using EnglishBooster.API.BusinessLogic.Models;
using EnglishBooster.API.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace EnglishBooster.API.BusinessLogic.Commands
{
	public class RecallCommand : ICommand
	{
		private readonly ITelegramBotClient telegramBotClient;
		private readonly Message message;

		public RecallCommand(ITelegramBotClient telegramBotClient, Message message)
		{
			this.telegramBotClient = telegramBotClient;
			this.message = message;
		}

		public async Task ExecuteAsync()
		{
			var word = new Word
			{
				IsNew = true,
				Meaning = "(англ.) Погнали",
				Value = "Let's go",
				RecallValues = new List<string>
				{
					"Побігли",
					"Ходу звідси"
				}
			};

			await telegramBotClient.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

			(var text, var inlineKeyboard) = GenerateRecallData(word);

			await telegramBotClient.SendTextMessageAsync(
				chatId: message.Chat.Id,
				text,
				parseMode: ParseMode.Markdown,
				replyMarkup: inlineKeyboard
			);
		}

		private (string, InlineKeyboardMarkup) GenerateRecallData(Word word)
		{
			var inlineKeyboard = new InlineKeyboardMarkup(GenerateInlineKeyboardButtons(word));

			var text = "Який переклад цього слова:" + Environment.NewLine + $"*{word.Value}*";

			return (text, inlineKeyboard);
		}

		private IEnumerable<IEnumerable<InlineKeyboardButton>> GenerateInlineKeyboardButtons(Word word)
		{
			word.RecallValues.Add(word.Meaning);
			var words = word.RecallValues.Shuffle();

			foreach (var item in words)
			{
				yield return new[]
				{
					InlineKeyboardButton.WithCallbackData(item, word.Value)
				};
			}
		}
	}
}
