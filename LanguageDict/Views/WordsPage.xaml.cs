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
                    addedWord.Word = newWord.ToLower();
                    addedWord.Translation = newTransl.ToLower();
                    addedWord.Meanings.Add(newMeanings.ToLower());
                    addedWord.Synonimus.Add(newSyno.ToLower());
                    addedWord.Antonyms.Add(newAnton.ToLower());
                    addedWord.Examples.Add(newExamp.ToLower());

                    DataBs server = new DataBs();
                    bool result = server.addNewWord(addedWord, SelectedDict.Target);

                    if (result)
                    {
                        SelectedDict.allWorlds.Add(addedWord);
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

    private async void RemoveWord()
    {
        if(SelectedWord != null)
        {
            DataBs server = new DataBs();
            bool result = server.removeWord(SelectedWord.Word, SelectedDict.Target);

            if (result)
            {
                for(int i = 0; i < SelectedDict.allWorlds.Count; i++)
                {
                    if (SelectedDict.allWorlds[i].Word == SelectedWord.Word)
                    {
                        SelectedDict.allWorlds.RemoveAt(i);
                    }
                }

                await DisplayAlert("Remove Word", "The word was removed", "OK");
            }else
            {
                await DisplayAlert("Remove Word", "The word wasn't removed", "OK");
            }
        }
    }

    private async void word_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            SelectedWord = (Words)e.CurrentSelection[e.CurrentSelection.Count - 1];

            if(SelectedWord != null)
            {
                string action = await DisplayActionSheet("Action", "Cancel", null, "See more details", "Remove word");

                if (action == "Remove word")
                {
                    RemoveWord();
                }
                else if (action == "See more details")
                {
                    DataBs server = new DataBs();
                    server.SetSelectedWord(SelectedWord);
                    await Shell.Current.GoToAsync(nameof(SeeMore));
                }
                else
                {
                    SelectedWord = null;
                }
            }
        }
    }

    private async void SearchWord(object sender, EventArgs e)
    {
        string word = searchBar.Text;

        if(word != null && word != "")
        {
            bool result = SelectedDict.Trie.SearchWord(word);

            if (result)
            {
                for(int i = 0; i < SelectedDict.allWorlds.Count; i++)
                {
                    if (SelectedDict.allWorlds[i].Word == word)
                    {
                        SearchedWord.Text = SelectedDict.allWorlds[i].Word;
                        break;
                    }
                }
            }else
            {
                await DisplayAlert("Search", "We didn't find this word on the dictionary", "OK");
            }
        }
    }

    private void GoTo(object sender, EventArgs e)
    {
        DataBs server = new DataBs();

        for(int i = 0; i < SelectedDict.allWorlds.Count; i++)
        {
            if (SelectedDict.allWorlds[i].Word == SearchedWord.Text)
            {
                SelectedWord = SelectedDict.allWorlds[i];
                break;
            }
        }

        server.SetSelectedWord(SelectedWord);
        Shell.Current.GoToAsync(nameof(SeeMore));
    }
}