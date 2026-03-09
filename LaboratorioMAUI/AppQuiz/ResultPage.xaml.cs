namespace AppQuiz;

public partial class ResultPage : ContentPage
{
	//Percorso dove leggere e salvare il file txt
	int _score = 0;

	private static readonly string _filePath = Path.Combine(
		FileSystem.AppDataDirectory, "bestscore.txt");

    public ResultPage(int score)
	{
		_score = score;
		InitializeComponent();
		ShowGUI();
    }

	private void ShowGUI()
	{
		if (!File.Exists(_filePath))
		{
			string content = File.ReadAllText(_filePath);
			string nome = content.Split(';')[0];
			string data = content.Split(';')[2];
            lblBestScore.Text = $"🏆 Miglior Punteggio: {LoadBestScore()}\n Di {nome} il {data}";
        }else
		{
			lblBestScore.Text = "🏆 Nessun punteggio presente";
        }
		lblScore.Text = _score.ToString();
        
    }

	private async void OnPlayAgainClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new MainPage());
    }

	private void OnSaveClicked(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(EntName.Text))
		{
			SaveBestScore(_score);
		}
		else
		{
			DisplayAlert("Attenzione", "Devi inserire il tuo nome", "OK");
		}
    }

    private int LoadBestScore()
	{
		if (!File.Exists(_filePath))
		{
			return 0;
		}

		//È buona abitudine gestire l'eccezione R/W!
		try
		{
			//Legge il contenuto del file txt
			string content = File.ReadAllText(_filePath);

			string point = content.Split(';')[1];

            int best;

			if (int.TryParse(point, out best))
			{
				return best;
            }
			else
			{
				DisplayAlert("Errore", "Il file del punteggio contiene un valore non valido.", "OK");
				return 0;
            }
		}catch (Exception ex)
		{
			DisplayAlert("Errore", "Lettura fallita: " + ex.Message, "OK");
			return 0;
        }
    }

	private void SaveBestScore(int score)
	{
		//Allochiamo lo score estrapolando dal file txt nella variabile best
		int best = LoadBestScore();

		//Se lo score del giocatore è maggiore di quello salvato
		if (score > best)
		{
			try
			{
				File.WriteAllText(_filePath,EntName.Text + ";" + score.ToString() + ";" + DateTime.Now.ToString("yyyy-MM-dd"));
                string content = File.ReadAllText(_filePath);
                string nome = content.Split(';')[0];
                string data = content.Split(';')[2];
                lblBestScore.Text = $"🏆 Miglior Punteggio: {LoadBestScore()}\n Di {nome} il {data}";
            }
			catch (Exception ex)
			{
				DisplayAlert("Errore", "Impossibile salvare il punteggio:" + ex.Message, "OK");
			}

		}
		else
		{
			DisplayAlert("Attenzione", "Il record è maggiore al tuo punteggio", "OK");
			ShowGUI();
		}
    }
}