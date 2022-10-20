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
        var fileImage = await FilePicker.Default.PickAsync();

		if( targetL != null && nativeL != null)
		{
			Dict nDict = new Dict();
			nDict.Target = targetL;
			nDict.Native = nativeL;
			nDict.Image = fileImage.FullPath;

			if (instMain.serverConnection.addNewDict(nDict))
			{
                instMain.AllDictionaries.Add(nDict);
            }

			await Shell.Current.GoToAsync(nameof(Views.MainPage));
		}


    }
}