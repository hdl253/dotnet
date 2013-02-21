using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;
using DerivativeCaculatorService;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace MDExchangeClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key when the service is ready.");
            Console.ReadKey(true);

            MetadataExchangeClient mdeClient = new MetadataExchangeClient(
                new Uri("http://localhost:8000/Derivatives/?wsdl"),
                MetadataExchangeClientMode.HttpGet);

            MetadataSet mdSet = mdeClient.GetMetadata();
            WsdlImporter importer = new WsdlImporter(mdSet);
            ServiceEndpointCollection endpoints = importer.ImportAllEndpoints();
            IDerivativeCaculator proxy = null;
            foreach (ServiceEndpoint endpoint in endpoints)
            {
                proxy = new ChannelFactory<IDerivativeCaculator>(endpoint.Binding, endpoint.Address).CreateChannel();
                ((IChannel)proxy).Open();
                Console.WriteLine(proxy.CaculateDerivative(
                    new string[] {"haodl"},
                    new decimal[]{3},
                    new string[]{}));
                ((IChannel)proxy).Close();
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }
    }
}
