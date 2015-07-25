// Just to show cast does not consume much time.

namespace CastExample
{
    using System.Diagnostics;
    using System;

    class A
    {
        
    }

    class B : A
    {
        public string Str0 { get; set; }
        public string Str1 { get; set; }
        public string Str2 { get; set; }
        public string Str3 { get; set; }
        public string Str4 { get; set; }
        public string Str5 { get; set; }
        public string Str6 { get; set; }
        public string Str7 { get; set; }
        public string Str8 { get; set; }
        public string Str9 { get; set; }
        public string Str10 { get; set; }
        public string Str11 { get; set; }
        public string Str12 { get; set; }
        public string Str13 { get; set; }
        public string Str14 { get; set; }
        public string Str15 { get; set; }
        public string Str16 { get; set; }
        public string Str17 { get; set; }
        public string Str18 { get; set; }
        public string Str19 { get; set; }
    }


    class Program
    {
        // Just to show cast does not consume much time.
        static void Main(string[] args)
        {
            Stopwatch st = new Stopwatch();
            st.Start();
            for (int i = 0; i < 1000000; i++)
            {
                B obj = new B();
                MapFieldValue(obj, "Str0", "str0");
                MapFieldValue(obj, "Str1", "str1");
                MapFieldValue(obj, "Str2", "str2");
                MapFieldValue(obj, "Str3", "str3");
                MapFieldValue(obj, "Str4", "str4");
                MapFieldValue(obj, "Str5", "str5");
                MapFieldValue(obj, "Str6", "str6");
                MapFieldValue(obj, "Str7", "str7");
                MapFieldValue(obj, "Str8", "str8");
                MapFieldValue(obj, "Str9", "str9");
                MapFieldValue(obj, "Str10", "str10");
                MapFieldValue(obj, "Str11", "str11");
                MapFieldValue(obj, "Str12", "str12");
                MapFieldValue(obj, "Str13", "str13");
                MapFieldValue(obj, "Str14", "str14");
                MapFieldValue(obj, "Str15", "str15");
                MapFieldValue(obj, "Str16", "str16");
                MapFieldValue(obj, "Str17", "str17");
                MapFieldValue(obj, "Str18", "str18");
                MapFieldValue(obj, "Str19", "str19");
            }
            Console.WriteLine(st.ElapsedTicks);
            st.Restart();
            for (int i = 0; i < 1000000; i++)
            {
                A obj = new B();
                MapFieldValue((B)obj, "Str0", "str0");
                MapFieldValue((B)obj, "Str1", "str1");
                MapFieldValue((B)obj, "Str2", "str2");
                MapFieldValue((B)obj, "Str3", "str3");
                MapFieldValue((B)obj, "Str4", "str4");
                MapFieldValue((B)obj, "Str5", "str5");
                MapFieldValue((B)obj, "Str6", "str6");
                MapFieldValue((B)obj, "Str7", "str7");
                MapFieldValue((B)obj, "Str8", "str8");
                MapFieldValue((B)obj, "Str9", "str9");
                MapFieldValue((B)obj, "Str10", "str10");
                MapFieldValue((B)obj, "Str11", "str11");
                MapFieldValue((B)obj, "Str12", "str12");
                MapFieldValue((B)obj, "Str13", "str13");
                MapFieldValue((B)obj, "Str14", "str14");
                MapFieldValue((B)obj, "Str15", "str15");
                MapFieldValue((B)obj, "Str16", "str16");
                MapFieldValue((B)obj, "Str17", "str17");
                MapFieldValue((B)obj, "Str18", "str18");
                MapFieldValue((B)obj, "Str19", "str19");
            }
            Console.WriteLine(st.ElapsedTicks);
            st.Stop();
            Console.ReadLine();
        }

        public static void MapFieldValue(B obj, string field, string value)
        {
            switch (field)
            {
                case "Str0":
                    obj.Str0 = value;
                    break;
                case "Str1":
                    obj.Str1 = value;
                    break;
                case "Str2":
                    obj.Str2 = value;
                    break;
                case "Str3":
                    obj.Str3 = value;
                    break;
                case "Str4":
                    obj.Str4 = value;
                    break;
                case "Str5":
                    obj.Str5 = value;
                    break;
                case "Str6":
                    obj.Str6 = value;
                    break;
                case "Str7":
                    obj.Str7 = value;
                    break;
                case "Str8":
                    obj.Str8 = value;
                    break;
                case "Str9":
                    obj.Str9 = value;
                    break;
                case "Str10":
                    obj.Str10 = value;
                    break;
                case "Str11":
                    obj.Str11 = value;
                    break;
                case "Str12":
                    obj.Str12 = value;
                    break;
                case "Str13":
                    obj.Str13 = value;
                    break;
                case "Str14":
                    obj.Str14 = value;
                    break;
                case "Str15":
                    obj.Str15 = value;
                    break;
                case "Str16":
                    obj.Str16 = value;
                    break;
                case "Str17":
                    obj.Str17 = value;
                    break;
                case "Str18":
                    obj.Str18 = value;
                    break;
                case "Str19":
                    obj.Str19 = value;
                    break;
            }
        }
    }
}
