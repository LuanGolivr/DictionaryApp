using LanguageDict.Models;
using System;

namespace LanguageDict.Views;

public partial class GetANewWord : ContentPage
{
    RestServicesDict _restService;
    RestServicesRandom _restServiceRandom;
    public string randomW { get; set; } = "";
    private WordOfTheD instanc { get; set;}
    private Root dictDat { get; set; }

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
                dictDat = dictData;
                instanc = new WordOfTheD(dictData);
                BindingContext = instanc;
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

    private async void AddToDict(object sender, EventArgs e)
    {
        if (WordText.Text != null && WordText.Text != "")
        {
            Main intancM = new Main();
            if (intancM.serverConnection.searchDict("English"))
            {
                string translate = await DisplayPromptAsync("Translation","Insert the translation of the word !!");
                Words currentWord = new Words(WordText.Text, translate, dictDat);

                
            }else
            {
                await DisplayAlert("Error", "You don't have an english dictioanry to add this word !!", "OK");            }
        }
    }
}