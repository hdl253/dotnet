using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace CPUUsageCurve
{
    class Program
    {
        /*提示：任务管理器刷新频率1s，任务管理器一个刷新周期内的cpu忙的时间和周期总时间的比率，就是cpu的占用率
         *      
         *      假设CPU主频2.0，则cpu时钟周期为2*10的9次方个时钟周期每秒
         *      
         *      现代CPU每个时钟周期可以执行两条以上的代码(汇编指令)
         *      
         *      
        */
        static void Main(string[] args)
        {
            //CPUUsage1();
            //CPUUsage2();
            //CPUUsage3(25);
            Program1.Main1(args);
        }

        //解法一:估算
        static void CPUUsage1()
        {
            Thread.BeginThreadAffinity();
            for (; ; )
            {
                for (int i = 0; i < 810000000; i++)
                {
                    ;
                }
                Thread.Sleep(100);
            }
            Thread.EndThreadAffinity();
        }
        //解法二：
        static void CPUUsage2()
        {
            int intBusyTime = 10;
            int intIdleTime = intBusyTime;
            int intStartTime = 0;
            while (true)
            {
                intStartTime = System.Environment.TickCount;
                while ((System.Environment.TickCount - intStartTime) <= intBusyTime) { }
                

                Thread.Sleep(intIdleTime);
            }
        }
        //解法三：调用性能计数器
        static void CPUUsage3(float level)
        {
            PerformanceCounter p = new PerformanceCounter("processor","% Processor Time","_Total");
            while(true)
            {
                Console.WriteLine(p.NextValue());
                if (p.NextValue() > level)
                {
                    Thread.Sleep(10);
                    Console.WriteLine("sleep");
                }
            }
        }
        static void CPUUsage3Inner()
        {
 
        }
       
    }
}
