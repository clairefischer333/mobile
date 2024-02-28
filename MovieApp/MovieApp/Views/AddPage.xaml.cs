//pull model in
using MovieApp.Models;

namespace MovieApp.Views;

public partial class AddPage : ContentPage
{
	public AddPage()
	{
		InitializeComponent();
		Title = "Add New Movie";
	}

    void Add_Clicked(System.Object sender, System.EventArgs e)
    {
		//add new movie to my collection
		var nm = new Movie();
		nm.Title = txtTitle.Text;
		nm.Rating = txtRating.Text;

		//add new movie to list
		App.MovieList.Add(nm);

		txtTitle.Text = "";
		txtRating.Text = "";
    }
}
