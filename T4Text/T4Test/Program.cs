/*
 * PROJECT : T4 Template Test
 * FILE : Program.cs
 * DATE 2017/04/22
 * DETAILS : This Main is for testing various parts of the T4 code generation.
 * 
 *  It also contains mechanisms (like reading XML) that are used by .tt files
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Configuration;

namespace T4Test
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("table_schema.xml");

            XmlNode root = xmlDoc.LastChild;
            Console.WriteLine("Parent node: " + root.Name);

            Dictionary<string, string> columnNode = new Dictionary<string, string>();

            foreach(XmlNode node in root)
            {
                string nameAttr = node.Attributes["name"].Value;
                string typeAttr = node.Attributes["type"].Value;

                columnNode[nameAttr] = typeAttr;
            }

            foreach(string s in columnNode.Keys)
            {
                string attribute = columnNode[s];
                Console.WriteLine(s + " " + attribute);
            }

            Product newProduct = new Product(7, "Ice Cream", 5.25m);

            string connStr = ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString;
            DAL dal = new DAL(connStr);


            dal.GetAll();
            dal.Add(newProduct);
            dal.Delete(6);

            Console.WriteLine("Program has ended . . .");
            Console.ReadKey();
        }
    }
}
