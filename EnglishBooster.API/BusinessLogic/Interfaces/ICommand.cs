using System.Threading.Tasks;

namespace EnglishBooster.API.BusinessLogic.Interfaces
{
	public interface ICommand
	{
		Task ExecuteAsync();
	}
}
