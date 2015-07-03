namespace StringBuilderTest
{
    using System;
    using System.Diagnostics;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch st = new Stopwatch();
            StringBuilder sb = new StringBuilder(string.Empty);
            st.Start();
            for (int i = 0; i < 100000; i++)
            {
                sb.Append("\"");
                sb.Append("X-AB-DEFGHJ-QWERTYUI-AS");
                sb.Append("\":");
                if (i%15 == 0)
                    sb.Clear();
            }
            st.Stop();
            Console.WriteLine(st.ElapsedTicks);

            Stopwatch st2 = new Stopwatch();
            st2.Start();
            StringBuilder sb2 = new StringBuilder(string.Empty);
            for (int i = 0; i < 100000; i++)
            {
                sb2.Append("\"" + "X-AB-DEFGHJ-QWERTYUI-AS" + "\":");
                if (i % 15 == 0)
                    sb2.Clear();
            }
            st2.Stop();
            Console.WriteLine(st2.ElapsedTicks);

            Console.ReadLine();
        }
    }
}
