using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceReference1.CalculatorServiceClient proxy = new ServiceReference1.CalculatorServiceClient())
            {
                Console.WriteLine("x+y={0}", proxy.Add(1, 2));
            }
        }
    }
}
