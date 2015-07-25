namespace ParallelExample
{
    using System;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[1000000];
            for (int i = 0; i < 1000000; i++)
            {
                arr[i] = i;
            }

            Parallel.ForEach(arr, value =>
            {
                for (int i = 0; i < 20000; i++) ;
            });

            Console.WriteLine("Parallel.ForEach finished ...");
            Console.ReadLine();
        }
    }
}
