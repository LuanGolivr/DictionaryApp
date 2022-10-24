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
        //CheckServerConnection();
        BindingContext = mainInst;
    }


	private async void AddNewDict(object sender, EventArgs e)
	{
        string targetL = TargetL.Text;
        string nativeL = NativeL.Text;

        if (targetL != null && nativeL != null)
        {
            Dict nDict = new Dict(nativeL, targetL);
            bool result = mainInst.serverConnection.addNewDict(nDict);


            if (result)
            {
                mainInst.AllDictionaries.Insert(0,nDict);
                Form.IsVisible = false;
                Form.Opacity = 0;
                dictCollection.IsVisible = true;
                dictCollection.Opacity = 1;

            }
            else
            {
                await DisplayAlert("Existed Dictionary", "Sorry, but this dictionary has already been created !!", "OK");
            }
        }
        else
        {
            await DisplayAlert("Error", "Invalid informations, try again !!", "OK");
        }
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

    private void CallForm(object sender, EventArgs e)
    {
        dictCollection.IsVisible = false;
        dictCollection.Opacity = 0;
        Form.IsVisible = true;
        Form.Opacity = 1;
    }

    private void dictCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }
}

