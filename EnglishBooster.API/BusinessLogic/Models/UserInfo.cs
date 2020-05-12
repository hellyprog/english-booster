using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishBooster.API.BusinessLogic.Models
{
	public class UserInfo
	{
		public ObjectId Id { get; set; }
		public long UserId { get; set; }
		public List<string> ViewedWords { get; set; }
	}
}
