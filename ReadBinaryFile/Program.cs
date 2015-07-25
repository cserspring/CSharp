namespace ReadBinaryFile
{
    using System.IO;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Byte[] result = File.ReadAllBytes("C:\\Users\\shuwa\\Desktop\\Data_2015_07_07_23.bond_bucket8");
            for (long i = 0; i < 100; i++)
            {
                Console.WriteLine(String.Format("{0,10:X}", result[i]));
            }
            Console.ReadLine();
        }
    }
}
