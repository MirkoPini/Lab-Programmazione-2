using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuiz.Models
{
    internal class TrueFalseQuestion : QuestionBase
    {
		private bool _correctAnswer;

		public bool CorrectAnswer
		{
			get { return _correctAnswer; }
			set { _correctAnswer = value; }
		}

        public TrueFalseQuestion(string text, int points,string img, bool correctAnswer)
			: base(text, points, img)
		{
			_correctAnswer = correctAnswer;
		}

        public override bool CheckAnswerTF(bool userAnswer)
        {
			return userAnswer == CorrectAnswer;
        }

        public override bool CheckAnswerOP(string userAnswer)
        {
            return false;
        }
    }
}
