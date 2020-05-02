using EnglishBooster.API.BusinessLogic.Interfaces;
using EnglishBooster.API.BusinessLogic.Models;
using EnglishBooster.API.DbAccess;
using EnglishBooster.API.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace EnglishBooster.API.BusinessLogic.Services
{
	public class MessageService : IMessageService
	{
		private readonly IWordRepository wordRepository;

		public MessageService(IWordRepository wordRepository)
		{
			this.wordRepository = wordRepository;
		}

		public async Task SendNewWord(ITelegramBotClient telegramBotClient, Message message)
		{
			var word = new Word
			{
				IsNew = true,
				Meaning = "(англ.) Погнали",
				Value = "Let's go"
			};

			await telegramBotClient.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

			await telegramBotClient.SendTextMessageAsync(
				chatId: message.Chat.Id,
				text: FormatNewWordText(word),
				parseMode: ParseMode.Markdown
			);
		}

		public async Task SendWordForRecall(ITelegramBotClient telegramBotClient, Message message)
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

		private string FormatNewWordText(Word word)
		{
			return $"*{word.Value}*{Environment.NewLine}{word.Meaning}";
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
					InlineKeyboardButton.WithCallbackData(item, (word.Meaning == item).ToString())
				};
			}
		}
	}
}
