using EnglishBooster.API.BusinessLogic.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishBooster.API.DbAccess
{
	public class WordRepository : IWordRepository
	{
		private readonly IMongoCollection<Word> wordsCollection;

		public WordRepository(string connectionString, string dbName)
		{
			var client = new MongoClient(connectionString);
			var database = client.GetDatabase(dbName);
			wordsCollection = database.GetCollection<Word>("Words");
		}

		public async Task<Word> GetWordAsync(string word)
		{
			var dbWord = await wordsCollection.Find(w => w.Value == word).FirstOrDefaultAsync();
			return dbWord;
		}

		public async Task<ICollection<Word>> GetWordsAsync()
		{ 
			var words = await wordsCollection.Find(new BsonDocument()).ToListAsync();
			return words;
		}
	}
}
