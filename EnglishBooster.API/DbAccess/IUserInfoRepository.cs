using EnglishBooster.API.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishBooster.API.DbAccess
{
	public interface IUserInfoRepository
	{
		Task<UserInfo> GetUserInfoAsync(long id);
		Task CreateUserInfoAsync(UserInfo userInfo);
		Task UpdateUserInfoAsync(UserInfo userInfo);
	}
}
