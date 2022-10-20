using LanguageDict.Models;
using Newtonsoft.Json;

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

			if(BindingContext is Models.Mainpage dict)
			{
				dict.AllDictionaries.Add(nDict);
				List<Dict> items = dict.ReadData(dict.dataPath);
				items.Insert(0,nDict);
				string jsonFile = JsonConvert.SerializeObject(items);
				dict.WriteData(jsonFile, dict.dataPath);
			}

			await Shell.Current.GoToAsync(nameof(Views.MainPage));
		}


    }
}