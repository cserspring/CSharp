using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadonlyDictionaryTest
{
    class Program
    {
        public static Dictionary<string, string> PrimarySecondaryRegions = new Dictionary<string, string>
        {
            {"A", "A"},
            {"B", "B"}
        };
        static void Main(string[] args)
        {
            PrimarySecondaryRegions.Add("C","C");

            foreach (var VARIABLE in PrimarySecondaryRegions.Keys)
            {
                Console.WriteLine(VARIABLE);
            }
            Console.ReadLine();
        }
    }
}
