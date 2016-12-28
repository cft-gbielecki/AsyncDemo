using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _6WithAsyncAndAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            Method();
            Console.WriteLine("Main Thread");
            Console.ReadLine();
        }

        public static async void Method()
        {
            Console.WriteLine("starting Method...");
            await Task.Run(new Action(LongTask));
            Console.WriteLine("New Thread");
        }

        public static void LongTask()
        {
            Thread.Sleep(20000);
        }
    }
}
