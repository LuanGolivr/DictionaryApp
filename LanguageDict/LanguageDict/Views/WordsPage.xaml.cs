using LanguageDict.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace LanguageDict.Views;

public partial class WordsPage : ContentPage
{
    private WordsP current;
    private Mainpage mainPage = new Mainpage();
    private List<Dict> currentDict = new List<Dict>();

    private Trie currentTrie = new Trie();
    private Dictionary<string, Dictionary<string, string>> currentWord = new Dictionary<string, Dictionary<string, string>>();

    public WordsPage()
    {
        InitializeComponent();
        BindingContext = new WordsP();

        if(BindingContext is WordsP w)
        {
            current = w;
        }

        currentDict = mainPage.ReadData(mainPage.selectedPath);

        for(int i = 0; i < mainPage.AllDictionaries.Count; i++) {

            if (currentDict[0].Target == mainPage.AllDictionaries[i].Target && currentDict[0].Native == mainPage.AllDictionaries[i].Native)
            {
                currentWord = mainPage.AllDictionaries[i].words;
                currentTrie = mainPage.AllDictionaries[i].Trie;
            }
        }
    }

    private async void AddNewWord(object sender, EventArgs e)
    {
        string word = await DisplayPromptAsync("Word", "Write down the word you want to insert in the dictionary: ");
        bool ans = true;

        if (word != null)
        {
            ans = currentTrie.SearchWord(word);

            if (!ans)
            {
                WordSelected newWord = new WordSelected();
                Dictionary<string, string> allValues = new Dictionary<string, string>();
                string transValue;
                string descrValue;
                string exampleValue;

                newWord.word = word;

                transValue = await DisplayPromptAsync("Translate", "Write down the translation of the word");
                if (transValue != null)
                {
                    newWord.translate = transValue;
                    allValues.Add("translate", transValue);
                    descrValue = await DisplayPromptAsync("Description", "Write down the description of the word");
                    
                    if(descrValue != null)
                    {
                        newWord.descr = descrValue;
                        allValues.Add("description", descrValue);
                        exampleValue = await DisplayPromptAsync("Example", "Write down an example of the word");

                        if (exampleValue != null)
                        {
                            newWord.examples = exampleValue;
                            allValues.Add("examples", exampleValue);

                            if (!currentWord.ContainsKey(word))
                            {
                                currentWord.Add(word, allValues);
                                current.AllWordsSelected.Add(newWord);
                                currentTrie.AddWord(word);
                                for (int i = 0; i < mainPage.AllDictionaries.Count; i++)
                                {
                                    if (currentDict[0].Target == mainPage.AllDictionaries[i].Target && currentDict[0].Native == mainPage.AllDictionaries[i].Native)
                                    {
                                        mainPage.AllDictionaries[i].words = currentWord;
                                        mainPage.AllDictionaries[i].Trie = currentTrie;
                                        string jsonFile = JsonConvert.SerializeObject(mainPage.AllDictionaries);

                                        mainPage.WriteData(jsonFile, mainPage.dataPath);
                                    }
                                }
                                await DisplayAlert("Word", "Word inserted successfully", "OK");
                            }
                        }
                    }
                } 
            }
            else
            {
                await DisplayAlert("Word", "The word has already been inserted", "OK");
            }
        }
    }

    private async void RemoveWord(object sender, EventArgs e)
    {
        string word = await DisplayPromptAsync("Word", "Write down the word you want to remove from the dictionary", "OK");
        bool ans = false;

        if (word != null)
        {
            ans = currentTrie.RemoveWord(word);

            if (ans)
            {
                if (currentWord.ContainsKey(word))
                {
                    WordSelected remWord = new WordSelected();
                    var element = currentWord[word];
                    remWord.word = word;
                    remWord.translate = element["translate"];
                    remWord.descr = element["description"];
                    remWord.examples = element["examples"];

                    currentWord.Remove(word);

                    for (int i = 0; i < current.AllWordsSelected.Count; i++)
                    {
                        if (current.AllWordsSelected[i].word == remWord.word)
                        {
                            current.AllWordsSelected.RemoveAt(i);
                        }
                    }

                    for (int i = 0; i < mainPage.AllDictionaries.Count; i++)
                    {
                        if (currentDict[0].Target == mainPage.AllDictionaries[i].Target && currentDict[0].Native == mainPage.AllDictionaries[i].Native)
                        {
                            mainPage.AllDictionaries[i].words = currentWord;
                            mainPage.AllDictionaries[i].Trie = currentTrie;
                            string jsonFile = JsonConvert.SerializeObject(mainPage.AllDictionaries);

                            mainPage.WriteData(jsonFile, mainPage.dataPath);
                        }
                    }
                }

            }
            else
            {
                await DisplayAlert("Word", "There is not this word in the dictionary.", "OK");
            }
        }
    }

    private async void SearchWord(object sender, EventArgs e)
    {
        string word = searchBar.Text;

        if (word != "")
        {
            bool ans = currentTrie.SearchWord(word);

            if (ans)
            {
                foreach(var item in currentWord)
                {
                    
                    if(item.Key.ToLower() == word.ToLower())
                    {
                        searchWord.Text = item.Key;
                        int i = 0;
                        foreach(var value in item.Value)
                        {
                            if(i == 0)
                            {
                                searchTranslate.Text = value.Value;
                            }
                            else if( i == 1)
                            {
                                searchDescription.Text = value.Value;
                            }else
                            {
                                searchExamples.Text = value.Value;
                            }
                            i++;
                        }
                    }
                }
                searchTable.Opacity = 1;
            }else
            {
                await DisplayAlert(word, "There is not this word in the dictionary", "OK");
            }
        }else
        {
            searchTable.Opacity = 0;
        }
    }
}