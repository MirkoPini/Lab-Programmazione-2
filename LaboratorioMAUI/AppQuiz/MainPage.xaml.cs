using AppQuiz.Models;
using System.Threading.Tasks;

namespace AppQuiz
{
    public partial class MainPage : ContentPage
    {
        private List<QuestionBase> _questions = new List<QuestionBase>();
        private int _currentIndex = 0;
        private int _score = 0;
        private int _numberOfQuestion;
        
        private static readonly string _fileQuestionsPath = Path.Combine(
            FileSystem.AppDataDirectory, "questions.txt");

        public MainPage()
        {
            InitializeComponent();
            SetupQuestions();
            var rnd = new Random();
            _questions = _questions.OrderBy(x => rnd.Next()).ToList();
        }

        private void SetupQuestions()
        {
            try
            {
                if (File.Exists(_fileQuestionsPath))
                {
                    string[] questions = File.ReadAllLines(_fileQuestionsPath);
                    foreach (string question in questions)
                    {
                        string QuestionType = question.Split(";")[0];
                        if (QuestionType.Equals("TF"))
                        {
                            string domanda = question.Split(";")[1];
                            string punteggio = question.Split(";")[2];
                            string risposta = question.Split(";")[3];
                            string img = question.Split(";")[4];
                            if (int.TryParse(punteggio, out int punti) && bool.TryParse(risposta, out bool soluzione))
                            {
                                _questions.Add(new TrueFalseQuestion(domanda, punti, img, soluzione));
                            }
                        }
                        else if (QuestionType.Equals("OPEN"))
                        {
                            string domanda = question.Split(";")[1];
                            string punteggio = question.Split(";")[2];
                            string risposta = question.Split(";")[3];
                            string img = question.Split(";")[4];
                            if(int.TryParse(punteggio, out int punti))
                            {
                                _questions.Add(new OpenQuestion(domanda, punti, img, risposta));
                            }
                        }
                    }
                }
                else
                {
                    DisplayAlert("Errore", "Nessuna domanda presente", "OK");
                }
                NumberQuestions();
            } catch(Exception ex)
            {
                DisplayAlert("Errore nelle domande", "Lettura fallita:" + ex.Message, "OK");
            }
        }

        private void NumberQuestions()
        {
            QuestionTextLabel.Text = $"Qunte domande vuoi fare (Max: {_questions.Count})?";
            AnswerEntry.Placeholder = "1, 2, ...";
            SubmitButton.Text = "OK";
            TrueButton.IsVisible = false;
            FalseButton.IsVisible = false;
            ImgQst.IsVisible = false;
            HintButton.IsVisible = false;
            btnResult.IsVisible = false;
        }

        private async Task ShowQuestion()
        {
            if (_currentIndex < _questions.Count && _currentIndex < _numberOfQuestion)
            {
                QuestionBase current = _questions[_currentIndex];
                QuestionTextLabel.Text = current.Text;
                ScoreLabel.Text = $"Punti: {_score}";
                ImgQst.Source = current.Img;
                if (current is TrueFalseQuestion)
                {
                    TrueButton.IsVisible = true;
                    FalseButton.IsVisible = true;
                    AnswerEntry.IsVisible = false;
                    SubmitButton.IsVisible = false;
                }
                else if (current is OpenQuestion)
                {
                    AnswerEntry.Text = "";
                    AnswerEntry.IsVisible = true;
                    SubmitButton.IsVisible = true;
                    TrueButton.IsVisible = false;
                    FalseButton.IsVisible = false;
                }
            }
            else
            {
                QuestionTextLabel.Text = $"Fine! Punteggio: {_score}";
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
            if ((SubmitButton.Text).Equals("OK"))
            {
                string questions = AnswerEntry.Text;
                if (int.TryParse(questions, out _numberOfQuestion))
                {
                    if (_numberOfQuestion <= _questions.Count && _numberOfQuestion > 0)
                    {
                        SubmitButton.Text = "Invia";
                        AnswerEntry.Placeholder = "Risposta aperta";
                        ImgQst.IsVisible = true;
                        HintButton.IsVisible = true;
                        ShowQuestion();
                    }
                    else
                    {
                        DisplayAlert("Errore", "Numero non valido", "OK");
                    }
                }
                else
                {
                    DisplayAlert("Errore", "Valore inserito non valido!", "OK");
                    NumberQuestions();
                }
            }
            else 
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
                } else if (_questions[_currentIndex] is OpenQuestion)
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
        }

        private void OnResetClicked(object sender, EventArgs e)
        {
            ScoreLabel.IsVisible = true;
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

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddQuestion());
        }
    }
}
