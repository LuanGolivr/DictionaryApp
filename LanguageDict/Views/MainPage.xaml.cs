using LanguageDict.Models;

namespace LanguageDict.Views;
public partial class MainPage : ContentPage
{
    private Dict selecDict = null;
	private Main mainInst { get; set; }

    public MainPage()
	{
		InitializeComponent();

		mainInst = new Main();
		CheckServerConnection();
        BindingContext = mainInst;
    }


	private async void CheckServerConnection()
	{
		if (mainInst.checkStatus() == false)
		{
			await DisplayAlert("Server Connection","It wasn't possible to make connection with the Server","OK");
		}
	}

	private async void AddNewDict(object sender, EventArgs e)
	{

    }

    private async void RemoveDict(object sender, EventArgs e)
    {
		
    }

    private async void DictCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		if(e.CurrentSelection.Count != 0)
		{
            selecDict = (Dict)e.CurrentSelection[0];
			
        }
    }
	
}

