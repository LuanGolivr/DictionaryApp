using LanguageDict.Models;

namespace LanguageDict.Views;

public partial class FormNewDictionary : ContentPage
{
	public FormNewDictionary()
	{
		InitializeComponent();
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

			await Shell.Current.GoToAsync(nameof(Views.MainPage));
		}


    }
}