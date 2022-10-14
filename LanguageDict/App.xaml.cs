namespace LanguageDict;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
		Routing.RegisterRoute(nameof(Views.WordsPage), typeof(Views.WordsPage));
	}
}
