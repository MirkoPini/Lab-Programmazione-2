using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numeri = new List<int>() { 1, 2, 3, 4, 5, 6};

            List<Studente> studenti = new List<Studente>();

            studenti.Add(new Studente("Giuseppe", 134));
            studenti.Add(new Studente("Simona", 105));

            //Vogliamo estrapolare i numeri pari della lista numeri
            //ToList() trasforma l'oggetto Ienumerable in lista

            List<int> pari = numeri.Where(n => n % 2 == 0).ToList();

            
            /*foreach (int x in pari)
            {
                Console.WriteLine(x);
            }*/

            var nomi = studenti.Select(x => x.Nome).ToList();

            List<int> crescenti = numeri.OrderBy(x => x).ToList();

            foreach (string n in nomi)
            {
                Console.WriteLine(n);
            }

            foreach (int n in crescenti)
            {
                Console.WriteLine(n);
            }

        }
    }
}
