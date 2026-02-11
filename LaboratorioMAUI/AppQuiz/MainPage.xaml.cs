using AppQuiz.Models;

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
            _questions.Add(new TrueFalseQuestion("Il C# è un linguaggio a oggetti?", 10, "c.png", true));
            _questions.Add(new TrueFalseQuestion("Python è un linguaggio compilato?", 10, "python.png", false));
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
            }
            else
            {
                QuestionTextLabel.Text = $"Fine! Punteggio finale: {_score}";
                TrueButton.IsVisible = false;
                FalseButton.IsVisible = false;
                ImgQst.IsVisible = false;
            }
        }
        private async void OnAnswerClicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            bool userAnswer = bool.Parse(btn.CommandParameter.ToString());

            if (_questions[_currentIndex].CheckAnswer(userAnswer))
            {
                _score += _questions[_currentIndex].Point;
                await DisplayAlert("Esatto!", "Hai indovinato.", "OK");
            }
            else
            {
                await DisplayAlert("Errore", "Riprova alla prossima", "OK");
            }
            _currentIndex++;
            ShowQuestion();
        }

        private void OnResetClicked(object sender, EventArgs e)
        {
            TrueButton.IsVisible = true;
            FalseButton.IsVisible = true;
            ImgQst.IsVisible = true;
            _currentIndex = 0;
            _score = 0;
            ShowQuestion();
        }

        private void OnHintClicked(object sender, EventArgs e)
        {
            if (_currentIndex < _questions.Count)
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
            }
        }
    }
}
