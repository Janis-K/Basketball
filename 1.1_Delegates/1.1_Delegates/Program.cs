using System;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Matematika del = null;
            PrintCmd();
            Console.WriteLine("Izvēle: ");
            int choice;
            int.TryParse(Console.ReadLine(), out choice);
            double one, two;
            Console.WriteLine("Pirmais: ");
            double.TryParse(Console.ReadLine(), out one);
            Console.WriteLine("Otrais: ");
            double.TryParse(Console.ReadLine(), out two);
            switch (choice)
            {
                case 1:
                    del += new Matematika(Saskaitit);
                    break;
                case 2:
                    del += new Matematika(Atnemt);
                    break;
                case 3:
                    del += new Matematika(Reizinat);
                    break;
                case 4:
                    del += new Matematika(Dalit);
                    break;
                default:
                    break;
            }

            Console.WriteLine(del(one, two));
            Console.ReadLine();
        }

        public delegate double Matematika(double one, double two);

        public static double Saskaitit(double one, double two)
        {
            return one + two;
        }

        public static double Atnemt(double one, double two)
        {
            return one - two;
        }

        public static double Reizinat(double one, double two)
        {
            return one * two;
        }

        public static double Dalit(double one, double two)
        {
            return one / two;
        }

        public static void PrintCmd()
        {
            Console.WriteLine("Izvelies darbību 1 - saskaitīt, 2 - atņemt, 3 - dalīt, 4 - reizināt");
        }
    }
}
