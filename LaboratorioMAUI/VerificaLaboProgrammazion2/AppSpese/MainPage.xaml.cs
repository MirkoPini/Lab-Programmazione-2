using AppSpese.Models;

namespace AppSpese
{
    public partial class MainPage : ContentPage
    {
        private string _rigaFormattata;

        string percorsoMesi = Path.Combine(
            FileSystem.AppDataDirectory, "mesi.txt");
        public MainPage()
        {
            InitializeComponent();
            ShowFile();
        }

        private async void OnSalvaClicked(object sender, EventArgs e)
        {
            if (File.Exists(percorsoMesi))
            {
                string descrizione = EntDescrizione.Text;
                string _importo = EntImporto.Text;
                string nomeLista = EntNomeLista.Text;
                double importo;

                if (!string.IsNullOrEmpty(descrizione) && !string.IsNullOrEmpty(_importo) && !string.IsNullOrEmpty(nomeLista))
                {
                    nomeLista += ".txt";
                    nomeLista.ToLower();
                    if (double.TryParse(_importo, out importo))
                    {
                        Spesa nuovaSpesa = new Spesa(descrizione, importo);
                        _rigaFormattata = nuovaSpesa.ToRiga();

                        if (CheckFile(nomeLista))
                        {
                            File.AppendAllText(percorsoMesi, nomeLista + Environment.NewLine);
                        }

                        string percorsoLista = Path.Combine(
                            FileSystem.AppDataDirectory, nomeLista);

                        File.AppendAllText(percorsoLista, _rigaFormattata + Environment.NewLine);
                        EntDescrizione.Text = "";
                        EntImporto.Text = "";
                        EntNomeLista.Text = "";
                        DisplayAlert("Fatto", "Spesa salvato con successo!", "OK");
                        ShowFile();
                    }
                }
                else
                {
                    DisplayAlert("Attenzione", "Valori inseriti non validi!", "OK");
                }
            }
            else
            {
                DisplayAlert("Attenzione", "Il File non esiste", "OK");
            }
        }

        public bool CheckFile(string nome)
        {
            if (File.Exists(percorsoMesi))
            {
                string[] nomiLista = File.ReadAllLines(percorsoMesi);
                
                foreach (string lista in nomiLista)
                {
                    if (nome.Equals(lista))
                    {
                        return false;
                    }
                }
                return true;
            } 
            else
            {
                DisplayAlert("Attenzione", "Il File non esiste", "OK");
                return true;
            }
        }

        public void ShowFile()
        {
            if (File.Exists(percorsoMesi))
            {
                EdiListe.Text = "";

                string[] nomiLista = File.ReadAllLines(percorsoMesi);
                foreach (string lista in nomiLista)
                {
                    EdiListe.Text += lista + "\n";
                }
            }
            else
            {
                DisplayAlert("Attenzione", "Il File non esiste", "OK");
            }
        }

        private async void OnVediCliCked(object sender, EventArgs e)
        {
            string path = EntNomeLista.Text;
            if (!string.IsNullOrEmpty(path) && CheckFile(path))
            {
                await Navigation.PushAsync(new DettaglioPage(path));
            }
            else
            {
                DisplayAlert("Attenzione", "File non presente", "OK");
            }
        }

    }

}
