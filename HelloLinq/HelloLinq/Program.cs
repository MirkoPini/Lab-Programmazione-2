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

            //Vogliamo estrapolare i numeri pari della lista numeri
            //ToList() trasforma l'oggetto Ienumerable in lista

            List<int> pari = numeri.Where(n => n % 2 == 0).ToList();

            
            foreach (int x in pari)
            {
                Console.WriteLine(x);
            }
        }
    }
}
