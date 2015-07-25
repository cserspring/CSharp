namespace DateTimeExample
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            DateTime Timestamp = DateTime.Parse("2015-05-11T20:33:55.6538885Z");
            Console.WriteLine(Timestamp.ToUniversalTime());
            Console.ReadLine();
        }
    }
}
