using System.Collections.Generic;
using MovieApp.Models;

namespace MovieApp;

public partial class App : Application
{
	public static List<Movie> MovieList;

	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
		//default constructor that starts everything

		//new list instance
		MovieList = new List<Movie>();
	}
}

