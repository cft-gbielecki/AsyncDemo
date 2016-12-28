using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _5WithoutAsyncAndAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            Method();
            Console.WriteLine("Main Thread");
            Console.ReadLine();
        }

        public static void Method()
        {
            Console.WriteLine("starting Method...");
            Task.Run(new Action(LongTask));
            Console.WriteLine("New Thread");
        }

        public static void LongTask()
        {
            Thread.Sleep(20000);
        }
    }
}
