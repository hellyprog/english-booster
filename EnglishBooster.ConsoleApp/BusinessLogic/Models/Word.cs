﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishBooster.BusinessLogic.Models
{
	public class Word
	{
		public int WordId { get; set; }
		public string Value { get; set; }
		public string Meaning { get; set; }
		public List<string> RecallValues { get; set; }
		public bool IsNew { get; set; }
	}
}