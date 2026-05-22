using AppAgenda.Models;
using Plugin.Maui.Calendar.Models;

namespace AppAgenda
{
    public partial class MainPage : ContentPage
    {
        private List<CalendarioModel> _events = new List<CalendarioModel>();

        private static readonly string _fileEventsPath = Path.Combine(
            FileSystem.AppDataDirectory, "events.txt");

        public EventCollection Events { get; set; }

        public MainPage()
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

        private void MostraProssimiEventi()
        {/*
            var prossimiEventi = _events.Where(x => )*/
        }

    }

}
