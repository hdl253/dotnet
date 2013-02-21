using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thread
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = new Task(() => Console.WriteLine("Write from another thread"));
            task.Start();
            Console.WriteLine("Main Thread");
            Console.ReadLine();

            for (int i = 0; i < 5; i++)
            {
                var t = new Task(obj => Console.WriteLine("Thread No " + obj), i);
                t.Start();
            }
            Console.ReadLine();

            var t1 = new Task<int>(() =>
            {
                int s = 0;
                for (int i = 0; i < 10000; i++)
                    s += i;
                return s;
            });
            t1.Start();
            Console.WriteLine("I'm computing");
            Console.WriteLine(t1.Result);
            Console.ReadLine();
        }
    }
}
