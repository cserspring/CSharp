using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLReaderWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IDictionary<string, string> > list = new List<IDictionary<string, string>>();
            IDictionary<string, string> dic = new Dictionary<string, string>();
            string k=string.Empty;
            string v = string.Empty;

            StreamReader streamReader = new StreamReader("C:\\Users\\shuwa\\Desktop\\Test.log");
            using (streamReader)
            using (var xmlReader = XmlReader.Create(streamReader))
            {
                XmlWriterSettings ws = new XmlWriterSettings();
                ws.Indent = true;

                using (XmlWriter writer = XmlWriter.Create("C:\\Users\\shuwa\\Desktop\\Test_New.log", ws))
                {

                    while (xmlReader.Read())
                    {
                        switch (xmlReader.NodeType)
                        {
                            case XmlNodeType.Element:

                                if (xmlReader.Name.Equals("E"))
                                {
                                    Console.Write("<E>");
                                    dic = new Dictionary<string, string>();
                                }
                                else if (xmlReader.Name.Equals("F"))
                                {
                                    Console.Write("<F>");
                                    if (xmlReader.HasAttributes)
                                    {
                                        k = xmlReader["n"];
                                        Console.Write(k);
                                    }
                                }
                                break;
                            case XmlNodeType.EndElement:
                                if (xmlReader.Name.Equals("E"))
                                {
                                    Console.Write("</E>");
                                    list.Add(dic);
                                }
                                else if (xmlReader.Name.Equals("F"))
                                {
                                    Console.Write("</F>");
                                }
                                break;
                            case XmlNodeType.Text:
                                v = xmlReader.Value;
                                dic.Add(k,v);
                                Console.Write(v);
                                break;
                        }
                    }

                }
            }
            /*
            // Create a writer to write XML to the console.
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create(Console.Out, settings);

            // Write the root element.
            writer.WriteStartElement("order");

            // Write an element with attributes.
            writer.WriteStartElement("item");
            writer.WriteAttributeString("date", "2/19/01");
            writer.WriteAttributeString("orderID", "136A5");

            // Write a full end element. Because this element has no 
            // content, calling WriteEndElement would have written a 
            // short end tag '/>'.
            writer.WriteFullEndElement();

            writer.WriteEndElement();

            // Write the XML to file and close the writer
            writer.Close();  
             */
        }
    }
}
