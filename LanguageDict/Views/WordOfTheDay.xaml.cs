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

    private async void Button_Clicked(object sender, EventArgs e)
    {
		if (!string.IsNullOrWhiteSpace(gettingWord.Text))
		{
			Root dictData = await _restService.GetDictData(GenerateRequestURL(DictAPI.OpenDictEndPoint));

			var teste = dictData.meanings[0].definitions[0].definition;
		}
    }

	private string GenerateRequestURL(string endpoint)
	{
		string requestURI = endpoint;
		requestURI += $"{gettingWord.Text}";
		return requestURI;
	}
}