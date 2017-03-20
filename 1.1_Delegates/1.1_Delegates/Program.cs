using System;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            //Matematika del = null;
            Matematika sum = delegate (double first, double second)
            {
                return first + second;
            };

            Matematika sub = delegate (double first, double second)
            {
                return first - second;
            };

            Matematika mult = delegate (double first, double second)
            {
                return first * second;
            };

            Matematika div = delegate (double first, double second)
            {
                return first / second;
            };

            PrintCmd();
            Console.WriteLine("Izvēle: ");
            int choice;
            int.TryParse(Console.ReadLine(), out choice);
            double one, two;
            double res = 0;
            Console.WriteLine("Pirmais: ");
            double.TryParse(Console.ReadLine(), out one);
            Console.WriteLine("Otrais: ");
            double.TryParse(Console.ReadLine(), out two);
            switch (choice)
            {
                case 1:
                    res = sum(one, two);
                    break;
                case 2:
                    res = sub(one, two);
                    break;
                case 3:
                    res = mult(one, two);
                    break;
                case 4:
                    res = div(one, two);
                    break;
                default:
                    break;
            }
            
            Console.WriteLine(res);
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
