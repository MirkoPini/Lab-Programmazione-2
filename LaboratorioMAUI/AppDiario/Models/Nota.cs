using System;

namespace AppDiario.Models
{
    public class Nota
    {
        private string _titolo;
        private string _testo;

        public string Titolo
        {
            get { return _titolo; }
            set 
            {
                if (String.IsNullOrEmpty(_titolo))
                {
                    _titolo = "Sconosciuto";
                }
                _titolo = value; }
        }

        public string Testo
        {
            get { return _testo; }
            set { _testo = value; }
        }

        public string DaOggettoARiga()
        {
            return this.Titolo + ";" + this.Testo;
        }

        public static Nota DaRigaAOggetto(string riga)
        {
            string[] parti = riga.Split(';');
            if (parti.Length < 2)
            {
                return null;
            }

            Nota nuovaNota = new Nota();
            nuovaNota.Titolo = parti[0];
            nuovaNota.Testo = parti[1];
            return nuovaNota;
        }
    }
}
