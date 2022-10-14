using LanguageDict.Models;
using Newtonsoft.Json;


namespace LanguageDict.Views;


public partial class MainPage : ContentPage
{
    private Dict selecDict = null;

    public MainPage()
	{
		InitializeComponent();	
		BindingContext = new Mainpage();
    }

	private async void AddNewDict(object sender, EventArgs e)
	{
		bool cont = true;
        string targetLang = await DisplayPromptAsync("Target Language", "What's the language you are learning ?");
		string nativeLang = "";
		string imagePath = "";

		if (targetLang == null)
			cont = false;

		if (cont) {
            nativeLang = await DisplayPromptAsync("Native Language", "What is the language you are using as an based ?");

			if (nativeLang == null)
				cont = false;
        }

		if (cont)
		{
            await DisplayAlert("Select Image", "Select an image to your new dictionary. (Optional)", "OK");
            try
			{
				var result = await FilePicker.Default.PickAsync();
				
				if(result != null)
				{
					imagePath = result.FullPath;
				}
			}
			finally
			{

			}
		}

		if(cont && (targetLang == "" || nativeLang == ""))
		{
			await DisplayAlert("Error", "You haven't inserted a valid name to Target/Native language.", "OK");
		}
		else if (cont)
		{
			Dict newDict = new Dict();
			newDict.Native = nativeLang;
			newDict.Target = targetLang;
			newDict.Image = imagePath;

			if(BindingContext is Models.Mainpage dict)
			{
				dict.AllDictionaries.Add(newDict);

				List<Dict> items = dict.ReadData(dict.dataPath);
				items.Insert(0, newDict);
				string jsonFile = JsonConvert.SerializeObject(items);
				dict.WriteData(jsonFile, dict.dataPath);
			}
		}	
    }

    private async void RemoveDict(object sender, EventArgs e)
    {
		if(selecDict != null)
		{
			bool answer = await DisplayAlert("Question", "Are you sure you want to remove this dictionary ?", "Yes", "No");
			if((BindingContext is Mainpage dict) && answer)
			{
                int idx = dict.AllDictionaries.IndexOf(selecDict);
                dict.AllDictionaries.Remove(selecDict);
				List<Dict> items = dict.ReadData(dict.dataPath);
				items.RemoveAt(idx);

				string jsonFile = JsonConvert.SerializeObject(items);
				dict.WriteData(jsonFile, dict.dataPath);

				selecDict = null;
                dictCollection.SelectedItem = null;
            }
		}
    }

    private async void DictCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		if(e.CurrentSelection.Count != 0)
		{
            selecDict = (Dict)e.CurrentSelection[0];
			string action = await DisplayActionSheet("What do you want to do ?", "Cancel", null, "Get in it ", "Remove");

			if (action == "Remove")
			{
				RemoveDict(sender, e);
			}
			else if (action == "Get in it ")
			{
                if (BindingContext is Mainpage dict)
				{
					List<object> selectedItem = new List<object>
					{
						selecDict
					};

                    string jsonItem = JsonConvert.SerializeObject(selectedItem);
                    dict.WriteData(jsonItem, dict.selectedPath);

					await Shell.Current.GoToAsync(nameof(WordsPage));
                }          
			}
            dictCollection.SelectedItem = null;
        }
    }
	
}

