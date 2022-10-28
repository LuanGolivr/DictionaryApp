using LanguageDict.Models;

namespace LanguageDict.Views;


public partial class WordsPage : ContentPage
{
    private Words selectedWord { get; set; }

    public WordsPage()
    {
        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }

    private async void word_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            selectedWord = (Words)e.CurrentSelection[e.CurrentSelection.Count - 1];

            if(selectedWord != null)
            {
                string action = await DisplayActionSheet("Action", "Cancel", null, "See Definition", "Remove word");

                if(action == "Remove word")
                {

                }
                else if(action == "See Definition")
                {

                }
                else
                {
                    selectedWord = null;
                }
            }
        }
    }
}