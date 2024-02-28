namespace MovieApp.Views;

public partial class FindPage : ContentPage
{
	public FindPage()
	{
		InitializeComponent();
		Title = "List Movies";
	}

	//make list appear
    protected override void OnAppearing()
    {
        base.OnAppearing();

		//creat template
		//let data template know what type we are using
		var MovieTemplate = new DataTemplate(typeof(TextCell));
		//bind to our model 
		MovieTemplate.SetBinding(TextCell.TextProperty, "Title");
        MovieTemplate.SetBinding(TextCell.DetailProperty, "Rating");

		//what is mapping to what
		lstMovies.ItemTemplate = MovieTemplate;

		//passing in data
		lstMovies.ItemsSource = App.MovieList;
    }
}
