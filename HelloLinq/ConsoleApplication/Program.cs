using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = Student.GetStudents();

            var over70 = students.Where(n => n.Grade > 70).ToList();

            foreach (Student v in over70)
            {
                Console.WriteLine(v.Grade);
            }
            
            var info = students.Where(x => x.Branch.Equals("Informatica"));


            foreach (Student v in info)
            {
                Console.WriteLine(v.Name);
            }

            bool like100 = students.Any(x => x.Grade == 100);

            Console.WriteLine(like100);

            bool more40 = students.All(x => x.Grade > 40);

            Console.WriteLine(more40);

            var firstTele = students.FirstOrDefault(x => x.Branch.Equals("Telecomunicazioni"));

            Console.WriteLine(firstTele.Name);

            var id1001 = students.SingleOrDefault(x => x.ID == 1001);

            Console.WriteLine(id1001.Name);

            //5

            List<string> nomi = students.Select(x => x.Name).ToList();

            foreach(string n in nomi)
            {
                Console.WriteLine(n);
            }

            foreach (string n in nomi)
            {
                string NOME = n.ToUpper();
                Console.WriteLine(NOME);
            }

            var result = students.Select(s => new { s.Name, s.Grade });
        }
    }
}
