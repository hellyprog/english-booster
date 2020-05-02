using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace EnglishBooster.API.BusinessLogic.Interfaces
{
	public interface IMessageService
	{
		Task SendNewWord(ITelegramBotClient telegramBotClient, Message message);
		Task SendWordForRecall(ITelegramBotClient telegramBotClient, Message message);
	}
}
