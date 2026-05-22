using AppAgenda.Models;
using Plugin.Maui.Calendar.Models;

namespace AppAgenda;

public partial class Eventi : ContentPage
{
	private List<CalendarioModel> _events = new List<CalendarioModel>();

	private static readonly string _fileEventsPath = Path.Combine(
		FileSystem.AppDataDirectory, "events.txt");

	public EventCollection Events { get; set; }

	public Eventi()
	{
		InitializeComponent();
		ShowEvents();
		BindingContext = this;
	}


    private void ShowEvents()
    {
        LeggiEventi();

        var collection = new EventCollection();

		// Questa parte di codice è stata generata con AI
        foreach (var evento in _events.GroupBy(e => e.Data.Date))
        {
            collection.Add(evento.Key, evento.ToList());
        }


        Events = collection;
        OnPropertyChanged(nameof(Events));
		//Fino a questo punto

    }

    private void LeggiEventi()
	{
		try
		{
			if (File.Exists(_fileEventsPath))
			{
				string[] events = File.ReadAllLines(_fileEventsPath);
                foreach (string evento in events)
                {
                    string data = evento.Split(';')[0];
					int giorno = Int32.Parse(data.Split('.')[0]);
					int mese = Int32.Parse(data.Split('.')[1]);
					int anno = Int32.Parse(data.Split('.')[2]);
					string nome = evento.Split(";")[1];
					string descrizione = evento.Split(";")[2];
					_events.Add(new CalendarioModel(new DateTime(anno, mese, giorno), nome, descrizione));
				}
			}

		}
		catch (Exception ex)
		{
			DisplayAlert("Errore", "Impossibili caricare gli eventi", "OK");
		}
	}

    private async void BtnAddEventClicked(object sender, EventArgs e)
    {
        if (Calendario.SelectedDate == null)
        {
            DisplayAlert("Attenzione", "Seleziona una data", "OK");
            return;
        }

        var data = Calendario.SelectedDate.Value;

        await Navigation.PushAsync(new AggiungiEvento(data));
    }

    private async void BtnRemoveEventClicked(object sender, EventArgs e)
    {
        var button = sender as Button;

        //Stringa scritta da AI
        var evento = button?.CommandParameter as CalendarioModel;

        if (evento == null) return;

        bool conferma = await DisplayAlert( "Conferma", $"Rimuovere '{evento.Nome}'?", "Sì", "No");

        if (!conferma) return;

        try
        {

            var righe = File.ReadAllLines(_fileEventsPath).ToList();

            string rigaDaRimuovere = null;

            foreach (string riga in righe)
            {
                string data = riga.Split(';')[0];
                string nome = riga.Split(';')[1];
                string descrizione = riga.Split(';')[2];

                if (data == evento.Data.ToString("dd.MM.yyyy") && nome == evento.Nome  && descrizione == evento.Descrizione)
                {
                    rigaDaRimuovere = riga;
                    break;
                }
            }

            if (rigaDaRimuovere != null)
            {
                righe.Remove(rigaDaRimuovere);
                File.WriteAllLines(_fileEventsPath, righe);
            }

            _events.Clear();
            ShowEvents();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Errore", "Impossibile rimuovere l'evento", "OK");
        }
    }

}