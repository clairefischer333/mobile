using ShoppingList.Models;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace ShoppingList.Views;

public partial class NewAccountPage : ContentPage
{
	public NewAccountPage()
	{
		InitializeComponent();
	}

	async void CreateAccount_Clicked(System.Object sender, System.EventArgs e)
	{
        //if pass if empty
        if (txtPassword.Text == string.Empty || txtPass2.Text == string.Empty)
        {
            await DisplayAlert("Error", "Enter a Password.", "OK");
            return;
        }
        //do passwords match
        if (txtPassword.Text != txtPass2.Text)
		{
			await DisplayAlert("Error", "Passwords do not match.", "OK");
			return;
		}
		
		//do valid email
		var pattern = "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$";
		Regex rg = new Regex(pattern);

		if (!rg.IsMatch(txtEmail.Text)){
            await DisplayAlert("Error", "Invalid Email", "OK");
			return;
        }
	

		//create acccount on api
		var data = JsonConvert.SerializeObject(new UserAccount(txtUser.Text, txtEmail.Text, txtPassword.Text));

		
		HttpClient client = new HttpClient();
		var Response = await client.PostAsync(new Uri("https://joewetzel.com/fvtc/account/createuser"), new StringContent(data, System.Text.Encoding.UTF8, "application/json"));
		var AccountStatus = Response.Content.ReadAsStringAsync().Result;

		//create account error?
		//user exists 
		if (AccountStatus=="user exists")
		{
            await DisplayAlert("Error", "This Username has been taken.", "OK");
            return;
        }
		//email exists
        if(AccountStatus == "email exists")

        {
            await DisplayAlert("Error", "This Email has already been used.", "OK");
            return;
        }
		//complete
        if (AccountStatus == "complete")
        {
             Response = await client.PostAsync(new Uri("https://joewetzel.com/fvtc/account/login"), new StringContent(data, System.Text.Encoding.UTF8, "application/json"));
            var Skey = Response.Content.ReadAsStringAsync().Result;

			if(string.IsNullOrEmpty(Skey) || Skey.Length > 50)
			{
                await DisplayAlert("Error", "An error happened loggin in.", "OK");
                return;
            }
			else
			{
				//login to app
				App.SessionKey = Skey;
				Navigation.PopModalAsync();
			}
        }
		else
		{
            await DisplayAlert("Error", "An error has occurred.", "OK");
            return;
        }


        //login on api
        App.SessionKey = "cc";
		Navigation.PopModalAsync();
    }
}
