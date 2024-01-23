namespace HelloWorld;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		if(lblDisplay.Text == "This is cool!!")
				{
			lblDisplay.Text = "Hello World";
		}
		else
		{
			lblDisplay.Text = "This is cool!!";
		}
	}
}


