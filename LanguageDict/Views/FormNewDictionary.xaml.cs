using LanguageDict.Models;

namespace LanguageDict.Views;

public partial class FormNewDictionary : ContentPage
{
	private Main instMain { get; set; }
	public FormNewDictionary()
	{
		InitializeComponent();
		instMain = new Main();
	}

    private async void CreateNewDict(object sender, EventArgs e)
    {
		string targetL = TargetL.Text;
		string nativeL = NativeL.Text;

		if( targetL != null && nativeL != null)
		{
			Dict nDict = new Dict();
			nDict.Target = targetL;
			nDict.Native = nativeL;
			bool result = instMain.serverConnection.addNewDict(nDict);


            if (result)
			{
                instMain.AllDictionaries.Add(nDict);
                await Shell.Current.GoToAsync("..");
            }else
			{
                await DisplayAlert("Existed Dictionary", "Sorry, but this dictionary has already been created !!", "OK");
            }
        }
        else
		{
			await DisplayAlert("Error","Invalid informations, try again !!", "OK");
        }

    }
}