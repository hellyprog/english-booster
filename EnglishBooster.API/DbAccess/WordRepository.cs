using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishBooster.API.DbAccess
{
	public class WordRepository : IWordRepository
	{
		private readonly MongoClient client;

		public WordRepository(string connectionString)
		{
			client = new MongoClient(connectionString);
			var dbName = connectionString.Substring(connectionString.LastIndexOf("/"));
			var db = client.GetDatabase(dbName);
		}
	}
}
