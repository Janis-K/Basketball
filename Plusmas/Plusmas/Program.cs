using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Plusmas
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thr = new Thread(Go);
            thr.IsBackground = true;
            thr.Start();
            thr.Join();
            for (int i = 0; i < 200; i++)
            {
                Console.WriteLine("T2");
            }
            Console.ReadLine();
        }

        public static void Go()
        {
            for (int i = 0; i < 200; i++)
            {
                Console.WriteLine("T1");
            }
        }
    }
}
