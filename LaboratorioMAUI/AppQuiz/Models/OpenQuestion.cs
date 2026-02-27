using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuiz.Models
{
    internal class OpenQuestion : QuestionBase
    {
        private string _correctAnswer;

        public string CorrectAnswer
        {
            get { return _correctAnswer; }
            set { _correctAnswer = value; }
        }

        public OpenQuestion(string text, int points, string img, string correctAnswer)
            : base(text, points, img)
        {
            _correctAnswer = correctAnswer;
        }

        public override bool CheckAnswerTF(bool userAnswer)
        {
            return false;
        }

        public override bool CheckAnswerOP(string userAnswer)
        {
            if (userAnswer.Equals(CorrectAnswer))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}