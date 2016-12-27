using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2AddTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();

            Task<int> carTask = Task.Factory.StartNew<int>(BookCar);
            Task<int> hotelTask = Task.Factory.StartNew<int>(BookHotel);
            Task<int> planeTask = Task.Factory.StartNew<int>(BookPlane);

            //int cardID = BookCar();
            //int hotelID = BookHotel();
            //int planeID = BookPlane();


            Task.WaitAll(carTask, hotelTask, planeTask);

            Console.WriteLine("Finished in {0} sec", sw.ElapsedMilliseconds / 1000.0);
            Console.ReadKey();
        }

        static Random rand = new Random();

        private static int BookHotel()
        {
            Console.WriteLine("Booking hotel...");
            Thread.Sleep(5000);
            Console.WriteLine("Done with hotel...");
            return rand.Next(100);
        }

        private static int BookPlane()
        {
            Console.WriteLine("Booking plane...");
            Thread.Sleep(8000);
            Console.WriteLine("Done with plane...");
            return rand.Next(100);
        }

        private static int BookCar()
        {
            Console.WriteLine("Booking car...");
            Thread.Sleep(3000);
            Console.WriteLine("Done with car...");
            return rand.Next(100);
        }
    }
}



//Najważniejsze w tym przykładzie

///1. Tworzenie zadania(Taska)
///2. Oczekiwanie na wynik
///3. Kontynnuj z wynikiem