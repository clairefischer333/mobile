using System;
namespace Marathon.Models
{
	public class RaceCollection
	{
		public race[] races { get; set; }
	}
	public class race
	{
		//matches server variable names
		public int id { get; set; }
		public string race_name { get; set; }
	}
	
}

