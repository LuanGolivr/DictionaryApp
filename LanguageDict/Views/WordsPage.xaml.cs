using LanguageDict.Models;

namespace LanguageDict.Views;


public partial class WordsPage : ContentPage
{
    private Words SelectedWord { get; set; }
    private Dict SelectedDict { get; set; }

    public WordsPage()
    {
        InitializeComponent();
        getSelectedDict();
        BindingContext = SelectedDict;
    }

    private void getSelectedDict()
    {
        DataBs server = new DataBs();
        SelectedDict = server.GetSelectedDict();
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }

    private async void AddNewWord(object sender, EventArgs e)
    {
        string newWord = string.Empty;
        string newTransl = string.Empty;
        string newMeanings = string.Empty;
        string newSyno = string.Empty;
        string newAnton = string.Empty;
        string newExamp = string.Empty;


        newWord = await DisplayPromptAsync("Word", "Insert the new word");

        if (newWord != null)
        {
            newTransl = await DisplayPromptAsync("Translation", "Insert the translation");

            if (newTransl != null)
            {
                newMeanings = await DisplayPromptAsync("Meaning", "Insert the meaning");

                if (newMeanings != null)
                {
                    newSyno = await DisplayPromptAsync("Synonimus", "Insert a synonimus");
                    newAnton = await DisplayPromptAsync("Antonimys", "Insert an antonymus");
                    newExamp = await DisplayPromptAsync("Example", "Insert an example");

                    Words addedWord = new Words();
                    addedWord.Word = newWord;
                    addedWord.Translation = newTransl;
                    addedWord.Meanings.Add(newMeanings);
                    addedWord.Synonimus.Add(newSyno);
                    addedWord.Antonyms.Add(newAnton);
                    addedWord.Examples.Add(newExamp);

                    DataBs server = new DataBs();
                    bool result = server.addNewWord(addedWord, SelectedDict.Target);

                    if (result)
                    {
                        SelectedDict = server.GetSelectedDict();
                        await DisplayAlert("Word", "The word was inserted sucessfuly!", "OK");
                    }
                    else
                    {
                        await DisplayAlert("Word", "The Word already exist", "OK");
                    }
                }
            }
        }
    }

    private void word_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }
}