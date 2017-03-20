using System;
using System.Threading;


class Threadi2
{
    //static void Main()
    //{
    //    new Thread(Go).Start();
    //    Go();
    //}

    static bool done;
    static readonly object locker = new object();
    static void Go()
    {
        lock (locker)
        {
            if (!done)
            {
                Thread.Sleep(1);
                done = true;
                Console.WriteLine("Done");
            }
        }
    }
}
//Metodes tiek sinhronizētas un tās izpildās ar 1ms atstarpi, noņemot lock - abi threadi izpildās vienlaikus