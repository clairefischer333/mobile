using ShoppingList.Models;
using Newtonsoft.Json;

namespace ShoppingList.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        
	}
    
    void NewAccount_Clicked(System.Object sender, System.EventArgs e)
    {
        Navigation.PushAsync(new NewAccountPage());
    }

    async void Login_Clicked(System.Object sender, System.EventArgs e)
    {

        HttpClient client = new HttpClient();
        var data = JsonConvert.SerializeObject(new UserAccount(txtUser.Text, txtPassword.Text));
        var Response = await client.PostAsync(new Uri("https://joewetzel.com/fvtc/account/login"), new StringContent(data, System.Text.Encoding.UTF8, "application/json"));
        var Skey = Response.Content.ReadAsStringAsync().Result;

        if (string.IsNullOrEmpty(Skey) || Skey.Length > 50)
        {
            await DisplayAlert("Error", "Wrong Username or Password.", "OK");
            return;
        }
        else
        {
            //save password
           
            //login to app
            App.SessionKey = Skey;
            Navigation.PopModalAsync();
        }

        Navigation.PopModalAsync();
            //push to add, pop to remove
    }
}
