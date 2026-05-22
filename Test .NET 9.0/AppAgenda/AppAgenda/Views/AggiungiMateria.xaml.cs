using AppAgenda.Models;
using System.Globalization;

namespace AppAgenda;

public partial class AggiungiMateria : ContentPage
{
    private string _filePath = Path.Combine(FileSystem.AppDataDirectory, "materie.txt");
	public AggiungiMateria()
	{
		InitializeComponent();
	}

    private async void BtnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(EntNomeMateria.Text)) {
            await DisplayAlert("Errore", "Il campo \"Nome materia\" è vuoto", "OK");
            return;
        }
        if (string.IsNullOrEmpty(EntNota.Text))
        {
            await DisplayAlert("Errore", "Il campo \"Nota\" è vuoto", "OK");
            return;
        }
        if (string.IsNullOrEmpty(EntPonderazioneNota.Text))
        {
            await DisplayAlert("Errore", "Il campo \"Nota\" è vuoto", "OK");
            return;
        }

        string nomeFile = EntNomeMateria.Text + ".txt";
        string percorsoMateria = Path.Combine(FileSystem.AppDataDirectory, nomeFile);

        if (!File.Exists(percorsoMateria))
        {
            File.AppendAllText(_filePath, nomeFile + Environment.NewLine);
        }

        try
        {
            Nota nota = new Nota
            {
                Valutazione = float.Parse(EntNota.Text),
                Ponderazione = float.Parse(EntPonderazioneNota.Text)
            };
            
            string filePath = $"{Path.Combine(FileSystem.AppDataDirectory, EntNomeMateria.Text)}.txt";

            File.AppendAllText(percorsoMateria, $"{nota.ToRiga()}{Environment.NewLine}");

        }
        catch (Exception) {
            await DisplayAlert("Errore", "Compilari i campi con i valori corretti", "Ok");
        }
        await Navigation.PushAsync(new Valutazioni());
    }


}