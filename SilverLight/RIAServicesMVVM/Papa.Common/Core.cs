using System;

namespace Papa.Common
{
    public class Core
    {
        public const string StateKeyParameter = "statekey";

        public static string NewKey()
        {
            return Guid.NewGuid().ToString().RemoveChar('-');
        }
    }
}