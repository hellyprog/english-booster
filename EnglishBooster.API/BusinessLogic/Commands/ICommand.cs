using System.Threading.Tasks;

namespace EnglishBooster.API.BusinessLogic.Commands
{
	public interface ICommand
	{
		Task ExecuteAsync();
	}
}
