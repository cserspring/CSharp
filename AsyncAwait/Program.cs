using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100000; ++i)
            {
                int ii = i;
                Task.Run(() => LogEvent(ii.ToString()));
            }
            Console.Read();
        }

        static void LogEvent(string me)
        {
            Console.WriteLine(me);
        }
    }
}
