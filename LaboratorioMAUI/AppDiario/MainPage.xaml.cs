using AppDiario.Models;

namespace AppDiario
{
    public partial class MainPage : ContentPage
    {
        string percorsoFile = Path.Combine(
            FileSystem.AppDataDirectory,
            "note.txt");

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnSalvaClicked(object sender, EventArgs e)
        {
            Nota nuovaNota = new Nota();

            nuovaNota.Titolo = EntTitolo.Text;
            nuovaNota.Testo = EntTesto.Text;

            if (string.IsNullOrEmpty(nuovaNota.Titolo))
            {
                await DisplayAlert("Errore", "Inserisci almeno il titolo", "OK");
            }

            string rigaDaScrivere = nuovaNota.DaOggettoARiga();

            File.AppendAllText(percorsoFile, rigaDaScrivere + Environment.NewLine);

            EntTitolo.Text = "";
            EntTesto.Text = "";

            await DisplayAlert("Fatto", "Nota salvata corretamente", "OK");
        }

        private void OnLeggiClicked(object sender, EventArgs e)
        {
            if (File.Exists(percorsoFile))
            {
                string[] righe = File.ReadAllLines(percorsoFile);
                EdiDisplay.Text = "";

                foreach (string riga in righe)
                {
                    Nota n = Nota.DaRigaAOggetto(riga);

                    if (n != null)
                    {
                        EdiDisplay.Text += "TITOLO: " + n.Titolo + "\n";
                        EdiDisplay.Text += "TESTO: " + n.Testo + "\n";
                        EdiDisplay.Text += "-----------------------\n";
                    }
                }
            } else
            {
                EdiDisplay.Text = "Il file è vuoto o non esiste.";
            }
        }

    }

}
