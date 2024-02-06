namespace DateNight.Views;

public partial class MoneyPage : ContentPage
{
	public MoneyPage()
	{
		InitializeComponent();
		Title = "Total Cost of Date!";
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		try
		{
			//get all of the values from pages
            lblDisplay.Text = App.dateCalc.GetTotalCost();
        }
        catch(Exception ex)
		{
			lblDisplay.Text = "$0.00";
			DisplayAlert("Error", ex.Message, "OK");
		}
		
    }
}
