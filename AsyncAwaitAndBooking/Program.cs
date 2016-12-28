using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _4ContinueWith
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();

            Task<int> carTask = BookCarAsync();
            Task<int> hotelTask = BookHotelAsync();
            Task<int> planeTask = BookPlane();//konwencja:powinno byc BookPlaneAsync

            Console.WriteLine("Finished booking:\n carId={0}, \nhotelId ={1}, \nplaneId={2}\n", carTask.Result, hotelTask.Result, planeTask.Result);

            Console.WriteLine("Finished in {0} sec", sw.ElapsedMilliseconds / 1000.0);
            Console.ReadKey();
        }

        static Random rand = new Random();

        private static async Task<int> BookHotelAsync()
        {
            Console.WriteLine("Booking hotel...");
            await Task.Run(() => LongTask(5000));
            Console.WriteLine("Done with hotel...");
            return rand.Next(100);
        }

        private static async Task<int> BookPlane()
        {
            Console.WriteLine("Booking plane...");
            await Task.Run(() => LongTask(8000));
            Console.WriteLine("Done with plane...");
            return rand.Next(100);
        }

        private static async Task<int> BookCarAsync()
        {
            Console.WriteLine("Booking car...");
            await Task.Run(() => LongTask(3000));
            Console.WriteLine("Done with car...");
            return rand.Next(100);
        }

        private static void LongTask(int sleepTime)
        {
            Thread.Sleep(sleepTime);
        }
    }
}



//Najważniejsze w tym przykładzie

///1. Tworzenie zadania(Taska)
///2. Oczekiwanie na wynik
///3. Kontynnuj z wynikiem
