using Newtonsoft.Json;
using ShoppingList.Models;

namespace ShoppingList.Views;

public partial class MainPage : ContentPage
{
	//instance of login page
	LoginPage LP = new LoginPage();

	//default constructor
	public MainPage()
	{
		InitializeComponent();
		Title = "Shopping List Pro";
        this.Loaded += MainPage_Loaded;
        LP.Unloaded += LP_Unloaded;
        lstData.Refreshing += LstData_Refreshing;
	}

     private void LstData_Refreshing(object sender, EventArgs e)
    {
        LoadData();
        lstData.IsRefreshing = false;
    }

    private void LP_Unloaded(object sender, EventArgs e)
    {
        OnAppearing1();
    }

    private void MainPage_Loaded(object sender, EventArgs e)
	{
		OnAppearing1();
	}

	
	public void OnAppearing1()
	{
		
		if (string.IsNullOrEmpty(App.SessionKey))
		{
            //doesnt allow user to use application until logged in
            Navigation.PushModalAsync(new NavigationPage(LP));
        }
		else
		{
            //Load data
            LoadData();
		}
		
	}

    void Logout_Clicked(System.Object sender, System.EventArgs e)
    {
		
        //Logout out of api
        HttpClient client = new HttpClient();
        var data = JsonConvert.SerializeObject(new UserAccount(App.SessionKey));
        client.PostAsync(new Uri("https://joewetzel.com/fvtc/account/logout"), new StringContent(data, System.Text.Encoding.UTF8, "application/json"));

        App.SessionKey = "";
        OnAppearing1();
    }

    async void AddData_Clicked(System.Object sender, System.EventArgs e)
    {
        //add items to API
        HttpClient client = new HttpClient();
        var data = JsonConvert.SerializeObject(new UserData(null, txtInput.Text, App.SessionKey));
        await client.PostAsync(new Uri("https://joewetzel.com/fvtc/account/data"), new StringContent(data, System.Text.Encoding.UTF8, "application/json"));

        txtInput.Text = "";
        LoadData();

    }
    async public void LoadData()
    {
        //load items from API
        HttpClient client = new HttpClient();
        var response = await client.GetAsync(new Uri("https://joewetzel.com/fvtc/account/data/" + App.SessionKey));
        var wsData = response.Content.ReadAsStringAsync().Result;

        //string/object data
        var data = JsonConvert.DeserializeObject<UserDataCollection>(wsData);

        //tie into list
        lstData.ItemsSource = data.UserDataItems;
    }

    void DeleteItem_Clicked(System.Object sender, System.EventArgs e)
    {
        //trigger clicked button
        var mi = (MenuItem)sender;
        var dataID = mi.CommandParameter.ToString();
        DeleteItems(dataID);
    }

    async public void DeleteItems(string dataID)
    {
        //delete items from api 
        HttpClient client = new HttpClient();
        var data = JsonConvert.SerializeObject(new UserData(dataID, null, App.SessionKey));
        

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Delete,
            RequestUri = new Uri("https://joewetzel.com/fvtc/account/data"),
            Content = new StringContent(data, System.Text.Encoding.UTF8, "application/json")
        };

        await client.SendAsync(request);
        LoadData();
    }

    void Delete_Clicked(System.Object sender, System.EventArgs e)
    {
        DeleteItems(null);
       
    }
}
