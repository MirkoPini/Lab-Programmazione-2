using AppQuiz.Models;
using System.Threading.Tasks;

namespace AppQuiz
{
    public partial class MainPage : ContentPage
    {
        private List<QuestionBase> _questions = new List<QuestionBase>();
        private int _currentIndex = 0;
        private int _score = 0;
        

        public MainPage()
        {
            InitializeComponent();
            _questions.Add(new TrueFalseQuestion("Python è un linguaggio compilato?", 10, "python.png", false));
            _questions.Add(new TrueFalseQuestion("C# è un linguaggio orientato agli oggetti?", 10, "c_sharp.png", true));
            _questions.Add(new TrueFalseQuestion("HTML è un linguaggio di programmazione?", 10, "html.png", false));
            _questions.Add(new TrueFalseQuestion("Java supporta il multithreading?", 10, "java.png", true));
            _questions.Add(new OpenQuestion("Come si chiama questo sistema operativo?", 10, "linux.png", "linux"));
            var rnd = new Random();
            _questions = _questions.OrderBy(x => rnd.Next()).ToList();
            ShowQuestion(); 
        }

        private void ShowQuestion()
        {
            if (_currentIndex < _questions.Count)
            {
                QuestionBase current = _questions[_currentIndex];
                QuestionTextLabel.Text = current.Text;
                ScoreLabel.Text = $"Punti: {_score}";
                ImgQst.Source = current.Img;
                btnResult.IsVisible = false;
                if (current is TrueFalseQuestion)
                {
                    TrueButton.IsVisible = true;
                    FalseButton.IsVisible = true;
                    AnswerEntry.IsVisible = false;
                    SubmitButton.IsVisible = false;
                }
                else if (current is OpenQuestion)
                {
                    AnswerEntry.IsVisible = true;
                    SubmitButton.IsVisible = true;
                    TrueButton.IsVisible = false;
                    FalseButton.IsVisible = false;
                }
            }
            else
            {
                string NamePlayer = NameEntry.Text;
                QuestionTextLabel.Text = $"Fine! Punteggio {NamePlayer}: {_score}";
                NameEntry.IsVisible = false;
                ScoreLabel.IsVisible = false;
                TrueButton.IsVisible = false;
                FalseButton.IsVisible = false;
                AnswerEntry.IsVisible = false;
                SubmitButton.IsVisible = false;
                ImgQst.IsVisible = false;
                HintButton.IsVisible = false;
                btnResult.IsVisible = true;
            }
        }
        private void OnAnswerClicked(object sender, EventArgs e)
        {
            if (_questions[_currentIndex] is TrueFalseQuestion)
            {
                var btn = (Button)sender;
                bool userAnswer = bool.Parse(btn.CommandParameter.ToString());

                if (_questions[_currentIndex].CheckAnswerTF(userAnswer))
                {
                    _score += _questions[_currentIndex].Point;
                    DisplayAlert("Esatto!", "Hai indovinato.", "OK");
                }
                else
                {
                    DisplayAlert("Errore", "Riprova alla prossima", "OK");
                }
            }else if (_questions[_currentIndex] is OpenQuestion)
            {
                var btn = (Button)sender;
                string userAnswer = AnswerEntry.Text.ToLower();
                if (_questions[_currentIndex].CheckAnswerOP(userAnswer))
                {
                    _score += _questions[_currentIndex].Point;
                    DisplayAlert("Esatto!", "Hai indovinato.", "OK");
                }
                else
                {
                    DisplayAlert("Errore", "Riprova alla prossima", "OK");
                }
            }
                _currentIndex++;
            ShowQuestion();
        }

        private void OnResetClicked(object sender, EventArgs e)
        {
            ScoreLabel.IsVisible = true;
            NameEntry.IsVisible = true;
            ImgQst.IsVisible = true;
            HintButton.IsVisible = true;
            _currentIndex = 0;
            _score = 0;
            ShowQuestion();
        }

        private void OnHintClicked(object sender, EventArgs e)
        {
            if (_currentIndex < _questions.Count)
            {
                _score -= (_questions[_currentIndex].Point)/2;
                ScoreLabel.Text = $"Punti: {_score}";
                if (_questions[_currentIndex] is TrueFalseQuestion)
                {
                    var current = _questions[_currentIndex] as TrueFalseQuestion;
                    bool hint = current.CorrectAnswer;
                    if (hint)
                    {
                        DisplayAlert("Suggerimento", "La risposta corretta è Vero.", "OK");
                    }
                    else
                    {
                        DisplayAlert("Suggerimento", "La risposta corretta è Falso.", "OK");
                    }
                }else if (_questions[_currentIndex] is OpenQuestion)
                {
                    var current = _questions[_currentIndex] as OpenQuestion;
                    string hint = current.CorrectAnswer;
                    DisplayAlert("Suggerimento", $"La risposta corretta è {hint}", "OK");
                }
            }
        }

        private void btnResult_Clicked(object sender, EventArgs e)
        {
            OnQuizFinished();
        }

        private async void OnQuizFinished()
        {
            //Richiamiamo il metodo PushAsync e gli passiamo il nuovo oggetto ResultPage
            //Attendiamo senza bloccare la pagina grazie ad await e async
            await Navigation.PushAsync(new ResultPage(_score));
        }

        private async void btnAbout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new About());
        }
    }
}
