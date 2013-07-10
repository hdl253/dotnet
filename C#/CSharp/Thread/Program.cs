using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Haodl.Thread
{
    class Program
    {
        static void Main1(string[] args)
        {
        }
    }
    class ParallelExample
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DirectoryBytes());
            Console.ReadLine();
        }

        static void ParallelSample()
        {
            Parallel.For(0, 100, it => Console.WriteLine("for:{0}", it));
            Parallel.ForEach<string>(new List<string>() { "a", "b", "c", "d" }, s => Console.WriteLine("Foreach:{0}", s));
            Parallel.Invoke(
                () => Console.WriteLine("Invoke1"),
                () => Console.WriteLine("Invoke2"),
                () => Console.WriteLine("Invoke3"),
                () => Console.WriteLine("Invoke4"));
            Console.ReadLine();
        }

        static long DirectoryBytes()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine(path);
            var files = Directory.EnumerateFiles(path);
            Console.WriteLine(files.Count());
            long result = 0;
            ParallelLoopResult results = Parallel.ForEach<string, long>(files,
                () => { return 0; },
                (file, loopstate, index, tasklocaltotal) =>
                {
                    long fileLen = 0;
                    FileStream fs = null;
                    try
                    {
                        fs = File.OpenRead(file);
                        fileLen = fs.Length;
                    }
                    catch (IOException) { }
                    finally
                    {
                        if (fs != null) fs.Dispose();
                    }
                    return tasklocaltotal + fileLen;
                },
                taskLocalTotal => { Interlocked.Add(ref result, taskLocalTotal); }
            );
            return result;
        }

    }


}
