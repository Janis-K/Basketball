using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anonymous
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> saraksts = new List<int>();

            Random r = new Random();

            for (int i = 0; i < 10; i++)
            {
                saraksts.Add(r.Next(0, 9));
            }

            Predicate<int> prime = delegate (int i)
            {
                if (i == 1) return false;
                if (i == 2) return true;

                for (int j = 2; j < i; ++j)
                {
                    if (i % j == 0) return false;
                }
                return true;
            };
            Console.WriteLine("Sākotnējais saraksts");
            Print(saraksts);
            Console.WriteLine("Find All");
            var pirmskaitluSaraksts = saraksts.FindAll(prime);
            Print(pirmskaitluSaraksts);
            Console.WriteLine("Find");
            var faind = saraksts.Find(prime);
            Console.WriteLine(faind);
            //saraksts.Remove(); 
            // Nav predikāta overloads
            Console.WriteLine("RemoveAll");
            saraksts.RemoveAll(prime);
            Print(saraksts);
            Console.ReadLine();
        }

        public static void Print (List<int> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
