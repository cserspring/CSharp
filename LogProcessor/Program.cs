namespace LogProcessor
{
    using System;
    using System.Diagnostics;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            string file = string.Empty;

            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-file":
                        file = args[++i];
                        break;
                    case "-help":
                        Usage();
                        break;
                }
            }

            long count = 0;
            long allTicks = 0;
            string start = "It takes";
            string end1 = "ticks to finishing processing 10 messages";

            long count2 = 0;
            long allTicks2 = 0;
            string end2 = "to process one message";

            long count3 = 0;
            long allTicks3 = 0;
            string end3 = "ticks to log one event";

            long count4 = 0;
            long allTicks4 = 0;
            string end4 = "ticks to get blob stream";

            long count5 = 0;
            long allTicks5 = 0;
            string end5 = "ticks to resolve the blob and log blob events";

            long count6 = 0;
            long allTicks6 = 0;
            string end6 = "ticks to resolve one xml event";

            StreamReader sr = new StreamReader(file);
            string line;
            while ((line = sr.ReadLine())!=null)
            {
                if (line.Contains(end1))
                {
                    Console.WriteLine(line);
                    int index1 = line.IndexOf(start, StringComparison.InvariantCulture);
                    int index2 = line.IndexOf(end1, StringComparison.InvariantCulture);
                    string number = line.Substring(index1 + start.Length + 1, index2 - 1 - (index1 + start.Length + 1));
                    allTicks += long.Parse(number);
                    ++count;
                }
                else if (line.Contains(end2))
                {
                    Console.WriteLine(line);
                    int index1 = line.IndexOf(start, StringComparison.InvariantCulture);
                    int index2 = line.IndexOf(end2, StringComparison.InvariantCulture);
                    string number = line.Substring(index1 + start.Length + 1, index2 - 1 - (index1 + start.Length + 1));
                    allTicks2 += long.Parse(number);
                    ++count2;
                }
                else if (line.Contains(end3))
                {
                    //Console.WriteLine(line);
                    int index1 = line.IndexOf(start, StringComparison.InvariantCulture);
                    int index2 = line.IndexOf(end3, StringComparison.InvariantCulture);
                    long number = long.Parse(line.Substring(index1 + start.Length + 1, index2 - 1 - (index1 + start.Length + 1)));
                    if (number < 1000)
                    {
                        allTicks3 += number;
                        ++count3;
                    }
                }
                else if (line.Contains(end4))
                {
                    Console.WriteLine(line);
                    int index1 = line.IndexOf(start, StringComparison.InvariantCulture);
                    int index2 = line.IndexOf(end4, StringComparison.InvariantCulture);
                    string number = line.Substring(index1 + start.Length + 1, index2 - 1 - (index1 + start.Length + 1));
                    allTicks4 += long.Parse(number);
                    ++count4;
                }
                else if (line.Contains(end5))
                {
                    Console.WriteLine(line);
                    int index1 = line.IndexOf(start, StringComparison.InvariantCulture);
                    int index2 = line.IndexOf(end5, StringComparison.InvariantCulture);
                    string number = line.Substring(index1 + start.Length + 1, index2 - 1 - (index1 + start.Length + 1));
                    allTicks5 += long.Parse(number);
                    ++count5;
                }
                else if (line.Contains(end6))
                {
                    Console.WriteLine(line);
                    int index1 = line.IndexOf(start, StringComparison.InvariantCulture);
                    int index2 = line.IndexOf(end6, StringComparison.InvariantCulture);
                    string number = line.Substring(index1 + start.Length + 1, index2 - 1 - (index1 + start.Length + 1));
                    allTicks6 += long.Parse(number);
                    ++count6;
                }
            }
            Console.WriteLine("It takes about {0} ticks to process 10 messages", allTicks/(count>0?count:1));
            Console.WriteLine("It takes about {0} ticks to process one message", allTicks2 / (count2 > 0 ? count2 : 1));
            Console.WriteLine("It takes about {0} ticks to log one event", allTicks3 / (count3 > 0 ? count3 : 1));
            Console.WriteLine("It takes about {0} ticks to get blob stream", allTicks4 / (count4 > 0 ? count4 : 1));
            Console.WriteLine("It takes about {0} ticks to resolve the blob and log blob events", allTicks5 / (count5 > 0 ? count5 : 1));
            Console.WriteLine("It takes about {0} ticks to resolve one xml event", allTicks6 / (count6 > 0 ? count6 : 1));

            Stopwatch st = new Stopwatch();
            st.Start();
            for (int i = 0; i < 100000; i++)
            {

            }
            //st.Stop();
            Console.WriteLine(st.ElapsedTicks);
            //st.Reset();

            st.Restart();
            for (int i = 0; i < 100000; i++)
            {

            }
            //st.Stop();
            Console.WriteLine(st.ElapsedTicks);
            Console.ReadLine();
        }

        static void Usage()
        {
            Console.WriteLine("-file [File Path]");
            Console.WriteLine("-help");
        }
    }
}
