using AppQuiz.Models;

namespace AppQuiz;

public partial class AddQuestion : ContentPage
{
    private string _questionsFile = Path.Combine(
            FileSystem.AppDataDirectory, "questions.txt");

    private string _password = "12345";
	private string _question;
	private string _answer;
	private bool _TrueFalse = false;
	private bool _OpenQuestion = false;

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
        entQuestion.IsVisible = false;
		lblTitolo.Text = "Soluzione della domanda:";
		btnOP.Text = "Vero";
        btnTF.Text = "Falso";
		if( _TrueFalse == true)
		{
			_answer = "false";
			SaveQuestion();
        } else
		{
            _question = entQuestion.Text;
            _TrueFalse = true;
		}
    }

	private void OnOPClicked(object sender, EventArgs e)
	{
		btnTF.IsVisible = false;
		btnOP.Text = "OK";
		lblTitolo.Text = "Soluzione della domanda:";
		entQuestion.Placeholder = "Inserisci la soluzione...";
		if (_OpenQuestion == true)
		{
			_answer = entQuestion.Text;
			SaveQuestion();
		} else
		{
            _question = entQuestion.Text;
            entQuestion.Text = "";
            _OpenQuestion = true;
		}
    }

	private async void SaveQuestion()
	{
		if (!string.IsNullOrEmpty(_question))
		{
			string nuovadomanda;
			if (_TrueFalse == true)
			{
				nuovadomanda = "TF;" + _question + ";10;" + _answer + ";img";

            } else if (_OpenQuestion == true)
			{
                nuovadomanda = "OPEN;" + _question + ";10;" + _answer + ";img";
			}
			else
			{
                DisplayAlert("Errore", "Quanlcosa è andato storto!", "OK");
                return;
			}

			File.AppendAllText(_questionsFile,
				nuovadomanda + Environment.NewLine);
            await DisplayAlert("Fatto", nuovadomanda , "OK");
            _OpenQuestion = false;
			_TrueFalse = false;
        }
		else
		{
			DisplayAlert("Errore", "La domanda non è valida!", "OK");
		}
	}
}