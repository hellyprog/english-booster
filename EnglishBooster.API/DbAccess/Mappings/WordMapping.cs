﻿using EnglishBooster.API.BusinessLogic.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace EnglishBooster.API.DbAccess.Mappings
{
	public static class WordMapping
	{
		public static void Register()
		{
			BsonClassMap.RegisterClassMap<Word>(cm =>
			{
				cm.AutoMap();
				cm.MapMember(p => p.Value).SetElementName("value");
				cm.MapMember(p => p.Meaning).SetElementName("meaning");
				cm.MapMember(p => p.RecallValues).SetElementName("recallValues");
				cm.MapMember(p => p.IsNew).SetElementName("isNew");
			});
		}
	}
}
