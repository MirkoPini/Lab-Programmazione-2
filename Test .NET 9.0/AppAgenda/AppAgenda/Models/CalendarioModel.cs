using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAgenda.Models
{
    internal class CalendarioModel
    {
		private DateTime _data;

		public DateTime Data
		{
			get { return _data; }
			set { _data = value; }
		}


		private string _nome;

		public string Nome
		{
			get { return _nome; }
			set { _nome = value; }
		}

		private string _descrizione;

		public string Descrizione
		{
			get { return _descrizione; }
			set { _descrizione = value; }
		}

        public CalendarioModel(DateTime data, string Nome, string Descrizione)
        {
			this.Data = data;
            this.Nome = Nome;
			this.Descrizione = Descrizione;
        }
    }
}
