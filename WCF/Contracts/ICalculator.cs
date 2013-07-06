using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Haodl.WCF
{
    [ServiceContract(Name="CalculatorService",Namespace="http://hdl253.com/")]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double x, double y);

        [OperationContract]
        double Subtract(double x, double y);

        [OperationContract]
        double Multipy(double x, double y);

        [OperationContract]
        double Divide(double x, double y);
    }
}
