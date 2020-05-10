using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnglishBooster.API.Extensions
{
	public static class ListExtensions
	{
        public static IList<T> Shuffle<T>(this IList<T> list)
        {
            var random = new Random();
            int n = list.Count;
            
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }

        public static T GetRandomElement<T>(this IList<T> list)
        {
            var random = new Random(DateTime.Now.Millisecond);

            return list.ElementAt(random.Next(list.Count()));
        }

        public static string ToTelegramMessageFormat(this List<string> list)
        {
            var sb = new StringBuilder();

            foreach (var item in list)
            {
                sb.AppendLine(item);
            }

            return sb.ToString();
        }
    }
}
