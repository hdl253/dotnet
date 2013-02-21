using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace DerivativeCaculatorService
{
    public class DerivativeCaculatorServiceType:IDerivativeCaculator
    {
        #region IDerivativeCaculator 成员

        decimal IDerivativeCaculator.CaculateDerivative(string[] symbols, decimal[] parameters, string[] functions)
        {
            return new DerivativesCaculator.Caculator().CaculateDerivative(symbols, parameters, functions);
        }

        void IDerivativeCaculator.DoNothing()
        {
            return;
        }

        #endregion
    }
}
