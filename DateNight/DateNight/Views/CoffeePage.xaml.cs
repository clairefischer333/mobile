namespace DateNight.Views;

public partial class CoffeePage : ContentPage
{
	public CoffeePage()
	{
		InitializeComponent();
		Title = "Going For Coffee!";

	}
	//on coffee page and now they are leaving 
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
		App.dateCalc.CoffeeCost = txtCoffee.Text;
    }
}
