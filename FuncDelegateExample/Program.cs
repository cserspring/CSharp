namespace FuncDelegateExample
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// predicate
    /// Type: System.Func<TSource, Int32, Boolean>
    /// A function to test each source element for a condition; the second parameter of 
    /// the function represents the index of the source element.
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> predicate = (str, index) => str.Length == index;
            string[] words = { "apple", "banana", "cat", "dog" };
            IEnumerable<string> result = words.Where(predicate).Select(str => str);
            foreach (var v in result)
            {
                Console.WriteLine(v);
            }

            Console.ReadLine();
        }
    }
}
