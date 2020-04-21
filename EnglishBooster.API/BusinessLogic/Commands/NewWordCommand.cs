using EnglishBooster.API.BusinessLogic.Models;
using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace EnglishBooster.API.BusinessLogic.Commands
{
	public class NewWordCommand : ICommand
	{
		private readonly ITelegramBotClient telegramBotClient;
		private readonly Message message;

		public NewWordCommand(ITelegramBotClient telegramBotClient, Message message)
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
				Value = "Let's go"
			};

			await telegramBotClient.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

			await telegramBotClient.SendTextMessageAsync(
					chatId: message.Chat.Id,
					text: FormatNewWordText(word),
					parseMode: ParseMode.Markdown
				);
		}

		private string FormatNewWordText(Word word)
		{
			return $"*{word.Value}*{Environment.NewLine}{word.Meaning}";
		}
	}
}
