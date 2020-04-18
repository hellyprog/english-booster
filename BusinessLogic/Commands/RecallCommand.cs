using EnglishBooster.BusinessLogic.Models;
using EnglishBooster.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace EnglishBooster.BusinessLogic.Commands
{
	public class RecallCommand : ICommand
	{
		private readonly ITelegramBotClient telegramBotClient;
		private readonly MessageEventArgs messageEventArgs;

		public RecallCommand(ITelegramBotClient telegramBotClient, MessageEventArgs messageEventArgs)
		{
			this.telegramBotClient = telegramBotClient;
			this.messageEventArgs = messageEventArgs;
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

			await telegramBotClient.SendChatActionAsync(messageEventArgs.Message.Chat.Id, ChatAction.Typing);

			(var text, var inlineKeyboard) = GenerateRecallData(word);

			await telegramBotClient.SendTextMessageAsync(
				chatId: messageEventArgs.Message.Chat.Id,
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
