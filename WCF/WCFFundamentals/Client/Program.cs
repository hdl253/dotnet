using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Client
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Press any key when the service is ready.");
            Console.ReadKey(true);

            decimal result = 0;
            using (DerivativeCaculatorClient client = new DerivativeCaculatorClient("BasicHttpBinding_IDerivativeCaculator"))
            {
                client.Open();
                result = client.CaculateDerivative(
                    new string[] { "haodl" },
                    new decimal[] { 0 },
                    new string[] { }
                    );
                client.Close();
            }

            Console.WriteLine(string.Format("Result:{0}",result));


            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);

            IDerivativeCaculator proxy = new ChannelFactory<IDerivativeCaculator>("BasicHttpBinding_IDerivativeCaculator").CreateChannel();

            result=proxy.CaculateDerivative(
                    new string[] { "haodl" },
                    new decimal[] { 0 },
                    new string[] { }
                    );
            ((IChannel)proxy).Close();

            Console.WriteLine(string.Format("Result:{0}", result));


            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);
        }
    }
}
