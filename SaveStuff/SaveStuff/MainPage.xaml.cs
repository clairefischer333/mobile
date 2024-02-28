namespace SaveStuff;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
	}

    void Save_Clicked(System.Object sender, System.EventArgs e)
    {
        //write something -> set it (key, value)
        //take it and save it 
        Preferences.Set("UserName", txtUserName.Text);
    }

    void Read_Clicked(System.Object sender, System.EventArgs e)
    {
        //get -> (key, default value)
        txtUserName.Text = Preferences.Get("UserName", "");
    }

    void Clear_Clicked(System.Object sender, System.EventArgs e)
    {
        //clear
        txtUserName.Text = string.Empty;
    }
}


