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
            _questions.Add(new TrueFalseQuestion("The Earth is flat.", 10, false));
            _questions.Add(new TrueFalseQuestion("The sky is blue.", 10, true));
            ShowQuestion();
        }

        private void ShowQuestion()
        {
            if(_currentIndex < _questions.Count)
            {
                QuestionBase current = _questions[_currentIndex];
                QuestionTextLabel.Text = current.Text;
                ScoreLabel.Text = $"Punti: {_score}";
            }
            else
            {
                QuestionTextLabel.Text = $"Fine! Punteggio finale: {_score}";
                TrueButton.IsVisible = false;
                FalseButton.IsVisible = false;
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
    }

}
