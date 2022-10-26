using LanguageDict.Models;

namespace LanguageDict.Views;

public partial class WordOfTheDay : ContentPage
{
	public RestServicesDict _restService;
	public RestServicesRandom _restServiceRandom;
	public string randomW { get; set; } = "";

	public WordOfTheDay()
	{
		InitializeComponent();
		_restServiceRandom = new RestServicesRandom();
		_restService = new RestServicesDict();

		GetRandomWord();
	}

	private async void GetRandomWord()
	{
		string result = await _restServiceRandom.getRandomWordData(RandomWordAPI.RandomWordEndPoint);
		randomW = result;
		GetDefinition();
;	}

	private async void GetDefinition()
	{
		if(randomW != null)
		{
			Root dictData = await _restService.GetDictData(GenerateRequestURL(DictAPI.OpenDictEndPoint));
			if(dictData == null)
			{
				GetRandomWord();
			}
            BindingContext = new WordOfTheD(dictData);
        }
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
	
	*/
	private string GenerateRequestURL(string endpoint)
	{
		string requestURI = endpoint;
		requestURI += $"{randomW}";
		return requestURI;
	}
	
}