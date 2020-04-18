﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishBooster.Extensions
{
	public static class ListExtensions
	{
        private static readonly Random random = new Random();

        public static IList<T> Shuffle<T>(this IList<T> list)
        {
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
    }
}
