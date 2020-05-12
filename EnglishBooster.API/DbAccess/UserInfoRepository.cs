using EnglishBooster.API.BusinessLogic.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishBooster.API.DbAccess
{
	public class UserInfoRepository : IUserInfoRepository
	{
		private readonly IMongoCollection<UserInfo> userInfoCollection;

		public UserInfoRepository(string connectionString, string dbName)
		{
			var client = new MongoClient(connectionString);
			var database = client.GetDatabase(dbName);
			userInfoCollection = database.GetCollection<UserInfo>("UserInfos");
		}

		public Task CreateUserInfoAsync(UserInfo userInfo)
		{
			return userInfoCollection.InsertOneAsync(userInfo);
		}

		public Task<UserInfo> GetUserInfoAsync(long id)
		{
			return userInfoCollection.Find(x => x.UserId == id).FirstOrDefaultAsync();
		}

		public Task UpdateUserInfoAsync(UserInfo userInfo)
		{
			return userInfoCollection.ReplaceOneAsync(x => x.Id == userInfo.Id, userInfo);
		}
	}
}
