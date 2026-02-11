using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuiz.Models
{
    internal abstract class QuestionBase
    {
		private int _point;

		public int Point
		{
			get { return _point; }
			set 
			{ 
				if(value < 0)
				{
					_point = 0;
				}
				else
				{
                    _point = value;
                }
			}
		}

		private string _text;

		public string Text
		{
			get { return _text; }
			set { _text = value; }
		}
	}
}
