using LanguageDict.Models;

namespace LanguageDict.Views;


public partial class WordsPage : ContentPage
{
    public DataBs Test { get; set; }

    public WordsPage()
    {
        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}