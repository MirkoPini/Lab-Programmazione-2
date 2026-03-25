using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSpese.Models
{
    internal class Spesa : VoceBase
    {
        private double _importo;
        private int _quantita;

        public double Importo
        {
            get { return _importo; }
            set { _importo = value; }
        }

        public int Quantita
        {
            get { return _quantita; }
            set { _quantita = value; }
        }

        public Spesa(string descrizione, double importo)
            : base(descrizione)
        {
            _importo = importo;
        }

        public override string ToRiga()
        {
            return this.Descrizione + ";" + this.Importo;
        }

        public static Spesa FromRiga(string riga)
        {
            string[] parti = riga.Split(';');
            double importo;
            if (parti.Length < 2)
            {
                return null;
            }
            if (double.TryParse(parti[1], out importo))
            {
                Spesa nuovaSpesa = new Spesa(parti[0], importo);
                return nuovaSpesa;
            }
            else
            {
                return null;
            }
        } 

    }
}
