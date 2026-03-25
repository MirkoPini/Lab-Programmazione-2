using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSpese.Models
{
    internal abstract class VoceBase
    {
        private string _descrizione;

		public string Descrizione
		{
			get { return _descrizione; }
			set { _descrizione = value; }
		}

		public VoceBase(string descrizione)
		{
			_descrizione = descrizione;
		}

		public abstract string ToRiga();
	}
}
