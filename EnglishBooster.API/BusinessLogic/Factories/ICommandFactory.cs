using EnglishBooster.API.BusinessLogic.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace EnglishBooster.API.BusinessLogic.Factories
{
	public interface ICommandFactory
	{
		ICommand GetCommand();
	}
}
