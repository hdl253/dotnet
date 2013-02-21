using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace BitFlags
{
    class Program
    {
        static void Main(string[] args)
        {

            string file = Assembly.GetEntryAssembly().Location;

            FileAttributes attributes = File.GetAttributes(file);
            Console.WriteLine(attributes);
            Console.WriteLine(FileAttributes.Hidden);
            Console.WriteLine(attributes & FileAttributes.Hidden);
            Console.WriteLine("Is {0} hidden ? {1}", file, (attributes & FileAttributes.Hidden) != 0);
        }
    }
}
