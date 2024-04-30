
using ShoppingList.Views;
namespace ShoppingList;

public partial class App : Application
{

	//accessible throughout app
	public static string SessionKey = "";

	public App()
	{
		InitializeComponent();
        //{"username": "cfish", "password": "test", "email": "fischer@fvtc.edu"}
        //E8774604A47942CE95322A39CA93F8C1

        MainPage = new NavigationPage(new MainPage());
	}
}

