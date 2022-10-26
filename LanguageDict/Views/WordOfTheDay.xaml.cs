using LanguageDict.Models;

namespace LanguageDict.Views;

public partial class WordOfTheDay : ContentPage
{
	RestServicesDict _restService;

	public WordOfTheDay()
	{
		InitializeComponent();
		_restService = new RestServicesDict();
		
	}

	/*
    private async void Button_Clicked(object sender, EventArgs e)
    {
		if (!string.IsNullOrWhiteSpace(gettingWord.Text))
		{
			Root dictData = await _restService.GetDictData(GenerateRequestURL(DictAPI.OpenDictEndPoint));
			BindingContext = new WordOfTheD(dictData);
		}
    }
	

	private string GenerateRequestURL(string endpoint)
	{
		string requestURI = endpoint;
		requestURI += $"{gettingWord.Text}";
		return requestURI;
	}
	*/
}