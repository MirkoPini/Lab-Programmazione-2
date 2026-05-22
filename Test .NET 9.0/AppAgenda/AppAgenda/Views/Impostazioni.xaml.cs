using Microsoft.Maui.Graphics.Text;
using System.Reflection;

namespace AppAgenda;

public partial class Impostazioni : ContentPage
{

    List<AppTheme> themeList = new List<AppTheme>();
    List<string> firstDayOfWeek = new List<string>();
    private static string _userDataFile = Path.Combine(FileSystem.AppDataDirectory, "userData.txt");

    public Impostazioni()
	{
		InitializeComponent();
        LoadPickers();
        LoadTheme();
        LoadUserData();
    }

    public void LoadPickers()
    {
        themeList.Add(AppTheme.Light);
        themeList.Add(AppTheme.Dark);
        PickTheme.ItemsSource = themeList;

        firstDayOfWeek.Add("Lunedì");
        firstDayOfWeek.Add("Martedì");
        firstDayOfWeek.Add("Mercoledì");
        firstDayOfWeek.Add("Giovedì");
        firstDayOfWeek.Add("Venerdì");
        firstDayOfWeek.Add("Sabato");
        firstDayOfWeek.Add("Domenica");
        PickFirstOfWeek.ItemsSource = firstDayOfWeek;
        PickFirstOfWeek.SelectedIndex = firstDayOfWeek.IndexOf("Lunedì");
    }

    // 
    public void LoadTheme()
	{
        if (Application.Current.RequestedTheme is AppTheme.Light)
        {
            PickTheme.SelectedIndex = themeList.IndexOf(AppTheme.Light);
        }
        else
        {
            PickTheme.SelectedIndex = themeList.IndexOf(AppTheme.Dark);
        }
	}

    public void LoadUserData()
    {
        if (File.Exists(_userDataFile))
        {
            string  text = File.ReadAllText(_userDataFile);

            string[] userData = text.Split(";");

            EntName.Text = userData[0];
            EntLastname.Text = userData[1];
            
            DateTime.TryParse(userData[2], out DateTime date);

            DatePickBirth.Date = date;

            LblBenvenuto.Text = "Benvenuto " + userData[0];

        }
    }


    private void PickTheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        AppTheme temaSelezionato = (AppTheme) PickTheme.SelectedItem;
        
        Application.Current.UserAppTheme = temaSelezionato; 
        

        if (temaSelezionato is AppTheme.Light)
        {
            imgUsericon.Source = "usericon_light.png";
        }
        else
        {
            imgUsericon.Source = "usericon_dark.png";
        }
    }

    private void BtnAnnulla_Clicked(object sender, EventArgs e)
    {
        LoadUserData();
    }

    private void BtnSalva_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(EntName.Text) || string.IsNullOrEmpty(EntLastname.Text))
            {
                DisplayAlert("Errore", "Riempire tutti i campi prima di salvare", "OK");
                return;
            }

            string name = EntName.Text.Trim();
            string lastname = EntLastname.Text.Trim();
            DateTime birthDay = DatePickBirth.Date;

            File.WriteAllText(_userDataFile, name + ";" + lastname + ";" + birthDay.ToString("dd.MM.yyyy"));
        }
        catch
        {
            DisplayAlert("Errore", "Errore nel salvataggio dei dati", "OK");
        }
    }

    private void PickFirstOfWeek_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}