using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GarbageCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer t = new Timer(TimerCallback, null, 0, 2000);
            Console.ReadLine();
        }

        private static void TimerCallback(object o)
        {
            Console.WriteLine("Time:" + DateTime.Now);
            GC.Collect();
        }
    }
}

