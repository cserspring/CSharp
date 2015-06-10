using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml;

namespace ResolveXMLInvalidChars
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            Stream stream =
                File.OpenRead(
                    "C:\\Users\\shuwa\\Desktop\\20150603T082708Z-20150603T082808Z-ASHWINWIN8-df08f87e373a4432bf8d0eab0e6456fb.log");
            //StreamReader sr = new StreamReader(stream, );
            var xmlReader = XmlReader.Create(stream);
            string message = "";
            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (xmlReader.Name.Equals("E"))
                        {
                            message = string.Empty;
                        }
                        else if (xmlReader.Name.Equals("F"))
                        {
                            message += "\"" + xmlReader["n"] + "\":";
                        }

                        break;
                    case XmlNodeType.EndElement:
                        if (xmlReader.Name.Equals("E"))
                        {
                            Console.WriteLine(message);
                        }

                        break;
                    case XmlNodeType.Text:
                        message += "\"" + xmlReader.Value + "\"\n";
                        break;
                }
            }
            stream.Close();
            stopwatch2.Stop();
            string time = stopwatch2.ElapsedMilliseconds.ToString();


            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            //Stream stream =
            //    File.OpenRead(
            //        "C:\\Users\\shuwa\\Desktop\\20150603T082708Z-20150603T082808Z-ASHWINWIN8-df08f87e373a4432bf8d0eab0e6456fb.log");

            //XmlDocument doc = new XmlDocument();
            //doc.Load(stream);

            //XmlNode eventsNode = doc.SelectSingleNode("/Events");
            //XmlNodeList eventNodeList = eventsNode.SelectNodes("E");

            //foreach (XmlNode eventNode in eventNodeList)
            //{
            //    XmlNodeList fieldNodeList = eventNode.SelectNodes("F");
            //    string content = string.Empty;
            //    foreach (XmlNode field in fieldNodeList)
            //    {
            //        content += "\"" + field.Attributes.GetNamedItem("n").Value + "\":\"" + field.InnerText + "\"\n";
            //    }
            //    Console.WriteLine(content);
            //}
            //stream.Close();
            //stopwatch.Stop();
            //string time = stopwatch.ElapsedMilliseconds.ToString();

            
            Console.WriteLine(time);
            Console.ReadLine();
        }
    }
}
