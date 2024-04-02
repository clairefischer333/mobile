﻿namespace CustomGPS;

public partial class MainPage : ContentPage
{
	//class variable
	GeolocationRequest request;

	public MainPage()
	{
		InitializeComponent();
		//set title
		Title = "Location Application";
		//set request equal to new instance
		request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
	}

    async void UpdateLocation_Clicked(System.Object sender, System.EventArgs e)
    {
		//async await to gather location 
		Location location = await Geolocation.Default.GetLocationAsync(request);

		lblLat.Text = "Lat: " + location.Latitude.ToString();
		lblLon.Text = "Lon: " + location.Longitude.ToString();

        var placemarks = await Geocoding.Default.GetPlacemarksAsync(location.Latitude, location.Longitude);
        Placemark placemark = placemarks?.FirstOrDefault();
       
        lblAddress.Text = placemark.SubThoroughfare + " " + placemark.Thoroughfare;
        lblAddress2.Text = placemark.Locality + " " + placemark.AdminArea + " " + placemark.PostalCode;
    }
    
}


