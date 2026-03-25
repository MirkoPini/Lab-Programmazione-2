namespace AppSpese;

public partial class DettaglioPage : ContentPage
{
	private string _path;

    public DettaglioPage(string Path)
	{
		InitializeComponent();
        _path = Path;
		ShowSpese();
    }

	public async void ShowSpese()
	{
		EdiListe.Text = "";
		lblPath.Text = _path;
        string percorsoSpese = Path.Combine(
            FileSystem.AppDataDirectory, _path + ".txt");
		if (File.Exists(percorsoSpese))
		{
			string[] spese = File.ReadAllLines(percorsoSpese);
			foreach(string spesa in spese)
			{
				string[] elementi = spesa.Split(";");
				EdiListe.Text += "DESCRIZIONE: " + elementi[0] + "\n";
				EdiListe.Text += "IMPORTO: " + elementi[1] + "\n";
				EdiListe.Text += "------------------\n";
			}
		} else
		{
			DisplayAlert("Attenzione", "File non presente", "OK");
		}
	}

    private async void OnIndietroClicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new MainPage());
    }
}