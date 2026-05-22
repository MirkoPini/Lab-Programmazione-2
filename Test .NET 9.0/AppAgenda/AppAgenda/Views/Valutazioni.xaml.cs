using AppAgenda.Models;

namespace AppAgenda;

public partial class Valutazioni : ContentPage
{
    private string _filePath = Path.Combine(FileSystem.AppDataDirectory, "materie.txt");
    public Valutazioni()
	{
		InitializeComponent();
	}

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new DettaglioValutazione());
    }

	private async void ShowGUI()
	{

	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await CaricaMaterie();
	}

	private async Task CaricaMaterie()
	{

		var materie = new List<Materia>();
	}
    private async void BtnAddSubjectClicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new AggiungiMateria());
    }
}