namespace AppQuiz;

public partial class About : ContentPage
{
	public About()
	{
		InitializeComponent();
	}

    private async void OnLinkTapped(object sender, EventArgs e)
    {
        await Launcher.OpenAsync("https://github.com/MirkoPini/Lab-Programmazione-2");
    }
}