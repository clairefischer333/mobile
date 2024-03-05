using System;
using SQLite;

namespace MovieApp.Models
{
	public class Repository
	{
		//private connection
		//underscore = read only 
		private readonly SQLiteConnection _database;
		public Repository()
		{
			//concatnating
			//tell us to give us folder path
			//make request and will create for us
			//make connection/find and we can interact
			var dbpath = Path.Combine(
				Environment.GetFolderPath(
				Environment.SpecialFolder.LocalApplicationData),
				"movies.db");

			//create database
			_database = new SQLiteConnection(dbpath);
			_database.CreateTable<Movie>();
		}

		public List<Movie> GetMovies()
		{
			//listing and returning our movie table
			return _database.Table<Movie>().ToList();
			//return _database.Query<Movie>("select * from Movie where ID > 3");
		}

        //pass in what we want saved
        public void SaveMovie(Movie movie)
		{
			_database.Insert(movie);

		}
	}
}

