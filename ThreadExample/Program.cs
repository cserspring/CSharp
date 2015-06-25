using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadExample
{
    public class Alpha
    {
        public void Beta()
        {
            while (true)
            {
                Console.WriteLine("Alpha.Beta is running in its own thread.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Thread Start/Stop/Join Sample");

            Alpha oAlpha = new Alpha();
            Thread oThread = new Thread(new ThreadStart(oAlpha.Beta));

            oThread.Start();

            while (!oThread.IsAlive) ;

            Thread.Sleep(1);

            oThread.Abort();

            oThread.Join(); // Prevent main thread stopping before oThread.

            Console.WriteLine();
            Console.WriteLine("Alpha.Beta has finished");

            try
            {
                Console.WriteLine("Try to restart the Alpha.Beta thread");
                oThread.Start();
            }
            catch (ThreadStateException)
            {
                Console.Write("ThreadStateException trying to restart Alpha.Beta. ");
                Console.WriteLine("Expected since aborted threads cannot be restarted.");
            }

            Console.ReadLine();
        }
    }
}
