//get into models
using DateNight.Models;

namespace DateNight;


public partial class App : Application
{
	//static refrence without instantiating it
	public static DateCalculator dateCalc;

	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
		dateCalc = new DateCalculator();
	}
}

