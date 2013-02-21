using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace DerivativeCaculatorService
{
    [ServiceContract]
    public interface IDerivativeCaculator
    {
        [OperationContract]
        decimal CaculateDerivative(string[] symbols,decimal[] parametors,string[] functions);
        void DoNothing();
    }
}
