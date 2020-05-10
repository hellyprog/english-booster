using EnglishBooster.API.BusinessLogic.Models;
using MongoDB.Bson.Serialization;

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
				cm.MapMember(p => p.Meanings).SetElementName("meanings");
				cm.MapMember(p => p.RecallValues).SetElementName("recallValues");
			});
		}
	}
}
