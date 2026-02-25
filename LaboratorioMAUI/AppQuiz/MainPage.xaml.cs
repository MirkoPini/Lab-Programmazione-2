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
            _questions.Add(new TrueFalseQuestion("Python è un linguaggio compilato?", 10, "python.png", false));
            _questions.Add(new TrueFalseQuestion("C# è un linguaggio orientato agli oggetti?", 10, "c_sharp.png", true));
            _questions.Add(new TrueFalseQuestion("HTML è un linguaggio di programmazione?", 10, "html.png", false));
            _questions.Add(new TrueFalseQuestion("Java supporta il multithreading?", 10, "java.png", true));
            _questions.Add(new TrueFalseQuestion("CSS serve per strutturare il contenuto di una pagina web?", 10, "css.png", false));
            _questions.Add(new TrueFalseQuestion("Un database relazionale utilizza tabelle?", 10, "database.png", true));
            _questions.Add(new TrueFalseQuestion("JavaScript può essere eseguito solo lato server?", 10, "javascript.png", false));
            _questions.Add(new TrueFalseQuestion("Il protocollo HTTP è stateless?", 10, "http.png", true));
            _questions.Add(new TrueFalseQuestion("SQL serve per creare animazioni 3D?", 10, "sql.png", false));
            _questions.Add(new TrueFalseQuestion("Un array può contenere più elementi dello stesso tipo?", 10, "array.png", true));
            _questions.Add(new TrueFalseQuestion("Il metodo GET è più sicuro del metodo POST per inviare password?", 10, "http.png", false));
            _questions.Add(new TrueFalseQuestion("Git è un sistema di controllo di versione?", 10, "git.png", true));
            _questions.Add(new TrueFalseQuestion("Un ciclo while viene eseguito sempre almeno una volta?", 10, "loop.png", false));
            _questions.Add(new TrueFalseQuestion("Il sistema binario utilizza solo le cifre 0 e 1?", 10, "binary.png", true));
            _questions.Add(new TrueFalseQuestion("Un firewall serve per aumentare la velocità della CPU?", 10, "security.png", false));
            _questions.Add(new TrueFalseQuestion("JSON è un formato di scambio dati?", 10, "json.png", true));
            _questions.Add(new TrueFalseQuestion("Un compilatore traduce il codice sorgente in linguaggio macchina?", 10, "compiler.png", true));
            _questions.Add(new TrueFalseQuestion("Linux è un sistema operativo open source?", 10, "linux.png", true));
            _questions.Add(new TrueFalseQuestion("Un indirizzo IP identifica un dispositivo in rete?", 10, "network.png", true));
            _questions.Add(new TrueFalseQuestion("La RAM conserva i dati anche senza alimentazione?", 10, "ram.png", false));
            _questions.Add(new TrueFalseQuestion("Un algoritmo è una sequenza finita di istruzioni?", 10, "algorithm.png", true));

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
            }
            else
            {
                string NamePlayer = NameEntry.Text;
                QuestionTextLabel.Text = $"Fine! Punteggio {NamePlayer}: {_score}";
                NameEntry.IsVisible = false;
                ScoreLabel.IsVisible = false;
                TrueButton.IsVisible = false;
                FalseButton.IsVisible = false;
                ImgQst.IsVisible = false;
                HintButton.IsVisible = false;
                btnResult.IsVisible = true;
            }
        }
        private void OnAnswerClicked(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            bool userAnswer = bool.Parse(btn.CommandParameter.ToString());

            if (_questions[_currentIndex].CheckAnswer(userAnswer))
            {
                _score += _questions[_currentIndex].Point;
                DisplayAlert("Esatto!", "Hai indovinato.", "OK");
            }
            else
            {
                DisplayAlert("Errore", "Riprova alla prossima", "OK");
            }
            _currentIndex++;
            ShowQuestion();
        }

        private void OnResetClicked(object sender, EventArgs e)
        {
            ScoreLabel.IsVisible = true;
            NameEntry.IsVisible = true;
            TrueButton.IsVisible = true;
            FalseButton.IsVisible = true;
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
                var current = _questions[_currentIndex] as TrueFalseQuestion;

                _score -= (_questions[_currentIndex].Point)/2;
                ScoreLabel.Text = $"Punti: {_score}";

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
    }
}
