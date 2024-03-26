namespace Marathon;

using Marathon.Models;
using Newtonsoft.Json;

public partial class MainPage : ContentPage
{
	RaceCollection RaceObject;

	public MainPage()
	{
		InitializeComponent();
		FillPicker();
	}

	private void FillPicker()
	{
		//create http client
		var client = new HttpClient();

		//base address - part that doesnt change
		client.BaseAddress = new Uri("https://joewetzel.com/fvtc/marathon/");

		//second part of url
		// gets response from http 
		var response = client.GetAsync("races/").Result;

		//peel json out
		var wsJson = response.Content.ReadAsStringAsync().Result;

		//put into race collection within array 
		RaceObject = JsonConvert.DeserializeObject<RaceCollection>(wsJson);

		//set race picker item source
		RacePicker.ItemsSource = RaceObject.races;
    }

    void RacePicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
    {
		//matched within collection to get id
		//throw collection at the picker
		//grab item out of picker
		//set index of the array that will give id of the race that was chosen 
		var SelectedRace = ((Picker)sender).SelectedIndex;
		var race_id = RaceObject.races[SelectedRace].id;


        var client = new HttpClient();
		client.BaseAddress = new Uri("https://joewetzel.com/fvtc/marathon/");
        var response = client.GetAsync("results/" + race_id).Result;
        var wsJson = response.Content.ReadAsStringAsync().Result;


		var ResultObject = JsonConvert.DeserializeObject<ResultsCollection>(wsJson);

		//create template and bind data 
		var CellTemplate = new DataTemplate(typeof(TextCell));
		CellTemplate.SetBinding(TextCell.TextProperty, "name");
        CellTemplate.SetBinding(TextCell.DetailProperty, "detail");

		//throwing collection at our list view 
		lstResults.ItemTemplate = CellTemplate;
		lstResults.ItemsSource = ResultObject.results;
    }
}


