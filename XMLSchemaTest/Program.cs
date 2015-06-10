using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace XMLSchemaTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly a = Assembly.GetExecutingAssembly();

            XmlSchema schema1 = null;
            XmlSchema schema2 = null;

            using (Stream stream = new FileStream("C:\\Users\\shuwa\\Desktop\\MonitoringPolicy.xsd", FileMode.Open))
            {
                schema1 = XmlSchema.Read(new XmlTextReader(stream), null);
            }

            using (Stream stream = new FileStream("C:\\Users\\shuwa\\Desktop\\MonitoringPolicy.xsd", FileMode.Open))
            {
                schema2 = XmlSchema.Read(stream, null);
            }

            Console.Write((object)schema1.Equals((object)schema2));
            
            Console.WriteLine(schema1.ToString());
            Console.WriteLine(schema2.ToString());
            Console.ReadLine();
        }
    }
}
