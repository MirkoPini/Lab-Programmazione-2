using AppQuiz.Models;

namespace AppQuiz;

public partial class AddQuestion : ContentPage
{
	private string _password = "12345";
	private string _question;

    public AddQuestion()
	{
		InitializeComponent();
        lblTitolo.IsVisible = false;
        entQuestion.IsVisible = false;
        btnTF.IsVisible = false;
        btnOP.IsVisible = false;
    }
	
	private void OnPasswordClicked(object sender, EventArgs e)
	{
        string _userpsw = entPsw.Text;
		if (_userpsw.Equals(_password))
		{
            lblTitolo.IsVisible = true;
            entQuestion.IsVisible = true;
            btnTF.IsVisible = true;
            btnOP.IsVisible = true;
			entPsw.IsVisible = false;
			lblPsw.IsVisible = false;
			btnPsw.IsVisible = false;
        }
        else
		{
			DisplayAlert("Attenzione", "Password errata", "OK");
		}
	}

	private void OnTFClicked(object sender, EventArgs e)
	{
		_question = entQuestion.Text;
        entQuestion.IsVisible = false;
		lblTitolo.Text = "Soluzione della domanda:";
		btnOP.Text = "Vero";
        btnTF.Text = "Falso";
		
    }
}