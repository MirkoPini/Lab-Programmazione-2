using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAgenda.Models
{
    public class Nota
    {

        private float _ponderazione;

        public float Ponderazione
        {
            get { return _ponderazione; }
            set { _ponderazione = value; }
        }

        private float _valutazione;
        public float Valutazione
        {
            get { return _valutazione; }
            set { _valutazione = value; }
        }

        public string ToRiga()
        {
            return $"{Valutazione.ToString()};{Ponderazione.ToString()}";
        }
    }
}
