using LanguageDict.Models;

namespace LanguageDict.Views;

public partial class SeeMore : ContentPage
{
	private Details CurrentWord { get; set; }
	public SeeMore()
	{
		InitializeComponent();
		UpdateData();
		BindingContext = CurrentWord;
	}

	private void UpdateData()
	{
		DataBs server = new DataBs();
		var data = server.GetSelectedWord();
		CurrentWord = new Details(data);
	}

    private void SaveChanges(object sender, EventArgs e)
    {

    }
}