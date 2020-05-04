using EnglishBooster.API.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishBooster.API.DbAccess
{
	public interface IWordRepository
	{
		Task<Word> GetWordAsync(string word);
		Task<ICollection<Word>> GetWordsAsync();
	}
}
