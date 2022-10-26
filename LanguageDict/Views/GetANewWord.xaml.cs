using LanguageDict.Models;
using System;

namespace LanguageDict.Views;

public partial class GetANewWord : ContentPage
{
    RestServicesDict _restService;
    RestServicesRandom _restServiceRandom;
    public string randomW { get; set; } = "";

    public GetANewWord()
	{
		InitializeComponent();
        _restServiceRandom = new RestServicesRandom();
        _restService = new RestServicesDict();
    }

    private async void GetRandomWord()
    {
        string result = await _restServiceRandom.getRandomWordData(RandomWordAPI.RandomWordEndPoint);
        randomW = result;
        GetDefinition();
        ;
    }

    private async void GetDefinition()
    {
        if (randomW != null)
        {
            Root dictData = await _restService.GetDictData(GenerateRequestURL(DictAPI.OpenDictEndPoint));
            if (dictData == null)
            {
                await DisplayAlert("Error", "We didn't get the word", "OK");
            }else
            {
                BindingContext = new WordOfTheD(dictData);
            }
            
        }
    }

    private string GenerateRequestURL(string endpoint)
    {
        string requestURI = endpoint;
        requestURI += $"{randomW}";
        return requestURI;
    }

    private void GetWord(object sender, EventArgs e)
    {
        GetRandomWord();
    }
}