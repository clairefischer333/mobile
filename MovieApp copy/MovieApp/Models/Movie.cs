using System;
using SQLite;
namespace MovieApp.Models
{
	public class Movie
	{
        //model-class with just properties
		//ID does not stay at 0 in database
        [PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public string Title { get; set; }
		public string Rating{ get; set; }
	}
}

