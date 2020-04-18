using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EnglishBooster.BusinessLogic.Commands
{
	public interface ICommand
	{
		Task ExecuteAsync();
	}
}
