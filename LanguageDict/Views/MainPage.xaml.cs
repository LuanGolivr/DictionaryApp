using LanguageDict.Models;

namespace LanguageDict.Views;
public partial class MainPage : ContentPage
{
    private Dict selecDict = null;
	private Main mainInst { get; set; }

    public MainPage()
	{
		InitializeComponent();

		mainInst = new Main();
        //CheckServerConnection();
        BindingContext = mainInst;
    }


	private async void AddNewDict(object sender, EventArgs e)
	{
        string targetL = TargetL.Text;
        string nativeL = NativeL.Text;

        if (targetL != null && nativeL != null)
        {
            Dict nDict = new Dict(nativeL.ToUpper(), targetL.ToUpper());
            bool result = mainInst.serverConnection.addNewDict(nDict);


            if (result)
            {
                mainInst.AllDictionaries.Insert(0,nDict);
                Form.IsVisible = false;
                Form.Opacity = 0;
                dictCollection.IsVisible = true;
                dictCollection.Opacity = 1;

            }
            else
            {
                await DisplayAlert("Existed Dictionary", "Sorry, but this dictionary has already been created !!", "OK");
            }
        }
        else
        {
            await DisplayAlert("Error", "Invalid informations, try again !!", "OK");
        }
    }

    private async void RemoveDict(Dict selectedDict)
    {
        if (mainInst.serverConnection.removeDict(selectedDict))
        {
            await DisplayAlert("Remove Dict", "The selected dictionary was deleted", "OK");
            mainInst.AllDictionaries.Remove(selectedDict);
        }else
        {
            await DisplayAlert("Remove Dict", "It wasn't possible to delete the dictionary , try again !!", "OK");
        }
    }

    private void CallForm(object sender, EventArgs e)
    {
        dictCollection.IsVisible = false;
        dictCollection.Opacity = 0;
        Form.IsVisible = true;
        Form.Opacity = 1;
    }

    private async void dictCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if(e.CurrentSelection.Count != 0)
        {
            selecDict = (Dict)e.CurrentSelection[0];

            if (selecDict != null)
            {
                string action = await DisplayActionSheet("Action", "Cancel", null, "Get into it", "Remove dictionary");

                if (action == "Remove dictionary")
                {
                    RemoveDict(selecDict);
                }
                else if (action == "Get into it")
                {
                    await Shell.Current.GoToAsync(nameof(WordsPage));
                }
                else
                {
                    selecDict = null;
                    dictCollection.SelectionMode = SelectionMode.None;
                }
            }

           
        }
    }

    private void Border_HandlerChanged(object sender, EventArgs e)
    {
        if(dictCollection.SelectionMode == SelectionMode.None)
        {
            dictCollection.SelectionMode = SelectionMode.Single;
        }
    }
}

