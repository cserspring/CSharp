namespace XMLSerializer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;

    [XmlRoot("Events")]
    public class Root
    {
        [XmlElement("E")]
        public List<E> Events { get; set; }
    }

    public class E
    {
        [XmlElement("F")]
        public List<F> Fields { get; set; }
    }
    public class F
    {
        [XmlAttribute("n")]
        public string Name { get; set; }
        [XmlText]
        public string Value { get; set; }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var ser = new XmlSerializer(typeof (Root));
            var obj = new Root
            {
                Events = new List<E>
                {
                    new E
                    {
                        Fields = new List<F>
                        {
                            new F{Name ="Date", Value = "2012-05-05"},
                            new F{Name ="Location", Value = "Redmond"}
                        }
                    },

                    new E
                    {
                        Fields = new List<F>
                        {
                            new F{Name ="Date", Value = "2012-06-05"},
                            new F{Name ="Location", Value = "Bluemond"}
                        }
                    }
                }
            };
            ser.Serialize(Console.Out, obj);

            XmlSerializer mySer = new XmlSerializer(typeof(Root));
            FileStream fs = new FileStream("Test.txt", FileMode.Open);
            Root root = (Root)mySer.Deserialize(fs);
            Console.ReadLine();
        }
    }
}
