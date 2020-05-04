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
		public string Meaning { get; set; }
		public List<string> RecallValues { get; set; }
		public bool IsNew { get; set; }
	}
}
