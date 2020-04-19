using EnglishBooster.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace EnglishBooster.BusinessLogic.Commands
{
	public class NewWordCommand : ICommand
	{
		private readonly ITelegramBotClient telegramBotClient;
		private readonly MessageEventArgs messageEventArgs;

		public NewWordCommand(ITelegramBotClient telegramBotClient, MessageEventArgs messageEventArgs)
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
				Value = "Let's go"
			};

			await telegramBotClient.SendChatActionAsync(messageEventArgs.Message.Chat.Id, ChatAction.Typing);

			await telegramBotClient.SendTextMessageAsync(
					chatId: messageEventArgs.Message.Chat.Id,
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
