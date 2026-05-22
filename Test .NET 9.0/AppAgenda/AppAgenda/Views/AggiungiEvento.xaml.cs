namespace AppAgenda;
using Plugin.Maui.Calendar.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

public partial class AggiungiEvento : ContentPage
{
	private DateTime _data;

    private static readonly string _fileEventsPath = Path.Combine(
        FileSystem.AppDataDirectory, "events.txt");

    public AggiungiEvento(DateTime data)
	{
		InitializeComponent();
		_data = data;
		ShowGui();
	}

	private void ShowGui()
	{
		LblTitolo.Text = "Aggiungi un evento il " + _data.Day + "." + _data.Month + "." + _data.Year + "!";
	}

    private void BtnSaveClicked(object sender, EventArgs e)
    {
		SaveEvent();
    }

    private async void SaveEvent() 
	{
		try
		{
			string[] events = File.ReadAllLines(_fileEventsPath);

			string titolo = EntTitolo.Text;
			string descrizione = EntDescrizione.Text;

			File.AppendAllText(_fileEventsPath, _data.ToString("dd.MM.yyyy") + ";" + titolo + ";" + descrizione + Environment.NewLine);

			DisplayAlert("Successo", "Evento salvato con successo!", "OK");
		} catch (Exception ex)
		{
			DisplayAlert("Errore", "Errore nel salvataggio dei dati", "OK");
		}

		await Navigation.PushAsync(new Eventi());
	}
}