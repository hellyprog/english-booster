using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace EnglishBooster.API.BusinessLogic.Interfaces
{
	public interface IWordService
	{
		Task SendNewWordAsync(ITelegramBotClient telegramBotClient, Message message);
		Task SendWordForRecallAsync(ITelegramBotClient telegramBotClient, Message message);
	}
}
