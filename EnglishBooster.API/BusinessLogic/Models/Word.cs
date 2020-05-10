using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishBooster.API.BusinessLogic.Models
{
	public class Word
	{
		public ObjectId Id { get; set; }
		public string Value { get; set; }
		public List<string> Meanings { get; set; }
		public List<string> RecallValues { get; set; }
	}
}
