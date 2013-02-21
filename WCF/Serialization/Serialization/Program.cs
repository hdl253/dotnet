using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Runtime.Serialization;
using System.Data;
using System.IO;

namespace Serialization
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(DerivativesCalculator),
                new Uri[] { new Uri("http://localhost:8000/Derivatives") }))
            {
                host.AddServiceEndpoint(typeof(IServiceViewOfService), new BasicHttpBinding(), "Calculator");
                host.Open();

                Console.WriteLine("available");

                string address = "http://localhost:8000/Derivatives/Calculator";
                ChannelFactory<IClientViewOfService> factory = new ChannelFactory<IClientViewOfService>(
                    new BasicHttpBinding(),
                    new EndpointAddress(new Uri(address)));
                IClientViewOfService proxy = factory.CreateChannel();

                decimal result = proxy.CalculateDerivative(
                    new string[] { "MSFT" },
                    new decimal[] { 3 },
                    new string[] { "hao" });
                Console.WriteLine("Value using XSD types is {0}:", result);

                DataTable table = new DataTable("InputTable");
                table.Columns.Add("Symbol", typeof(string));
                table.Columns.Add("Parameter",typeof(decimal));
                table.Columns.Add("Functions",typeof(string));
                table.Columns.Add("Value", typeof(decimal));

                table.Rows.Add("MSFT", 3, "hao", 0.00);

                DataSet input = new DataSet("Input");
                input.Tables.Add(table);

                DataSet output = proxy.CalculateDerivative(input);
                if (output != null)
                {
                    if (output.Tables.Count > 0)
                    {
                        if (output.Tables[0].Rows.Count > 0)
                        {
                            Console.WriteLine("Value using a DataSet is {0}.", output.Tables[0].Rows[0]["Value"]);
                        }
                    }
                }
                ClientViewOfData calculation = new ClientViewOfData();
                calculation.Parameters = new decimal[] { 3 };
                calculation.Functions = new string[] { "hao" };
                calculation.Reference = Guid.NewGuid();

                Console.WriteLine("Reference is {0}", calculation.Reference);

                ClientViewOfData calculationResult = proxy.CalculateDerivative(calculation);

                Console.WriteLine("Value using a data Contract {0}.", calculationResult.Value);

                Console.WriteLine("Reference is {0}", calculationResult.Reference);

                DerivedData derivedData = new DerivedData();
                Data outputData = proxy.DoSomething(derivedData);

                MemoryStream stream = new MemoryStream();
                DataContractSerializer serializer = new DataContractSerializer(typeof(ClientViewOfData));
                serializer.WriteObject(stream, calculation);
                Console.WriteLine(UnicodeEncoding.UTF8.GetChars(stream.GetBuffer()));

                Console.WriteLine("Done.");

                try
                {
                    decimal quotient = proxy.DivideByZero(9);

                }
                catch(FaultException<SomeError> error) {
                    Console.WriteLine("Error:{0}", error.Detail.Content);
                }

                ((IChannel)proxy).Close();

                host.Close();
                Console.ReadKey();


            }
        }
    }

    [DataContract(Name="Caculation")]
    public class ServerViewOfData:IExtensibleDataObject
    {
        [DataMember(Name = "Symbols")]
        private string[] symbols;
        [DataMember(Name = "Parameters")]
        private decimal[] parameters;
        [DataMember(Name = "Functions")]
        private string[] functions;
        [DataMember(Name = "Value")]
        private decimal value;

        private ExtensionDataObject extensibleData;

        public string[] Symbols { get { return symbols; } set { symbols = value; } }
        public decimal[] Parameters { get { return parameters; } set { parameters = value; } }
        public string[] Functions { get { return functions; } set { functions = value; } }
        public decimal Value 
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value=value;
            }
        }
        #region IExtensibleDataObject 成员

        public ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensibleData;
            }
            set
            {
                this.extensibleData = value;
            }
        }

        #endregion
    }

    [DataContract]
    public class Data
    {
        [DataMember]
        public string Value;
    }

    [DataContract]
    public class DerivedData : Data
    { }

    [DataContract(Name = "Caculation")]
    public class ClientViewOfData : IExtensibleDataObject
    {
        [DataMember(Name = "Symbols")]
        public string[] Symbols;
        [DataMember(Name = "Parameters")]
        public decimal[] Parameters;
        [DataMember(Name = "Functions")]
        public string[] Functions;
        [DataMember(Name = "Value")]
        public decimal Value;
        [DataMember(Name = "Reference")]
        public Guid Reference;

        private ExtensionDataObject extensibleData;

        #region IExtensibleDataObject 成员

        public ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensibleData;
            }
            set
            {
                this.extensibleData = value;
            }
        }

        #endregion
    }

    [ServiceContract(Name = "DerivativesCalculator")]
    [ServiceKnownType(typeof(DerivedData))]
    public interface IServiceViewOfService
    {
        [OperationContract(Name = "FromXSDTypes")]
        decimal CalculateDerivative(
            string[] symbols,
            decimal[] parameters,
            string[] functions);

        [OperationContract(Name = "FromDataSet")]
        DataSet CalculateDerivative(DataSet input);

        [OperationContract(Name = "FromDataContract")]
        ServerViewOfData CalculateDerivative(ServerViewOfData input);

        [OperationContract(Name = "AlsoFromDataContract")]
        Data DoSomething(Data input);

        [OperationContract(Name="Faulty")]
        [FaultContract(typeof(SomeError))]
        decimal DivideByZero(decimal input);

    }
    [ServiceContract(Name = "DerivativesCalculator")]
    [ServiceKnownType(typeof(DerivedData))]
    public interface IClientViewOfService
    {
        [OperationContract(Name = "FromXSDTypes")]
        decimal CalculateDerivative(
            string[] symbols,
            decimal[] parameters,
            string[] functions);

        [OperationContract(Name = "FromDataSet")]
        DataSet CalculateDerivative(DataSet input);

        [OperationContract(Name = "FromDataContract")]
        ClientViewOfData CalculateDerivative(ClientViewOfData input);

        [OperationContract(Name = "AlsoFromDataContract")]
        Data DoSomething(Data input);


        [OperationContract(Name = "Faulty")]
        [FaultContract(typeof(SomeError))]
        decimal DivideByZero(decimal input);

    }

    public class DerivativesCalculator : IServiceViewOfService
    {
        #region IServiceViewOfData 成员

        public decimal CalculateDerivative(string[] symbols, decimal[] parameters, string[] functions)
        {
            return (decimal)System.DateTime.Now.Millisecond;
        }

        public DataSet CalculateDerivative(DataSet input)
        {
            if (input.Tables.Count > 0)
            {
                if (input.Tables[0].Rows.Count > 0)
                {
                    input.Tables[0].Rows[0]["Value"] = (decimal)System.DateTime.Now.Millisecond;
                }
            }
            return input;
        }

        public ServerViewOfData CalculateDerivative(ServerViewOfData input)
        {
            input.Value = this.CalculateDerivative(input.Symbols, input.Parameters, input.Functions);
            return input;
        }

        public Data DoSomething(Data input)
        {
            return input;
        }

        #endregion


        #region IServiceViewOfService 成员


        public decimal DivideByZero(decimal input)
        {
            try
            {
                decimal denominator = 0;
                return input / denominator;
            }
            catch(Exception ex)
            {
                SomeError error = new SomeError();
                error.Content = ex.Message;
                throw new FaultException<SomeError>(error);
            }
        }

        #endregion
    }

    [DataContract]
    public class SomeError
    {
        [DataMember]
        public string Content;
    }

}
