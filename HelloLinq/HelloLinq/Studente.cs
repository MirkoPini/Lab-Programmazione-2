using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloLinq
{
    internal class Studente
    {
        public string Nome { get; set; }

        public int Anni { get; set; }

        public Studente(string nome, int anni) 
        {
            this.Nome = nome;
            this.Anni = anni;
        }
    }
}
