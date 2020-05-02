using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace EnglishBooster.API.BusinessLogic.Interfaces
{
	public interface ICommandFactory
	{
		ICommand GetCommand(Update update);
	}
}
