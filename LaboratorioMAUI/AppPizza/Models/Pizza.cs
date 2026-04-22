using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPizza.Models
{
    internal class Pizza
    {
		private string _nome;

		public string Nome
		{
			get { return _nome; }
			set { _nome = value; }
		}

		private double _prezzo;

		public double Prezzo
		{
			get { return _prezzo; }
			set { _prezzo = value; }
		}

		private string _ingredienti;

		public string Ingredienti
		{
			get { return _ingredienti; }
			set { _ingredienti = value; }
		}

		private string _image;

		public string Immagine
		{
			get { return _image; }
			set { _image = value; }
		}


		public Pizza(string nome, double prezzo, string ingredienti, string immagine)
        {
            Nome = nome;
			Prezzo = prezzo;
			Ingredienti = ingredienti;
			Immagine = immagine;
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return Nome + ";" + Prezzo + ";" + Ingredienti + ";" + Immagine;
        }
    }
}
