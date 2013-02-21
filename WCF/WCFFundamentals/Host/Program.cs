using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using DerivativeCaculatorService;

namespace Host
{
    class Program
    {
        public static void Main(string[] args)
        {
            Type serviceType = typeof(DerivativeCaculatorService.DerivativeCaculatorServiceType);

            using (ServiceHost host = new ServiceHost(serviceType))
            {
                //Uri tcpAddress = new Uri("http://localhost:8099/Derivative");
                //host.AddServiceEndpoint(typeof(IDerivativeCaculator), new BasicHttpBinding(), tcpAddress);
                host.Open();
                Console.WriteLine("available");
                Console.ReadKey(true);
                host.Close();
            }
        }
    }
}
