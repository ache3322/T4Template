/*
* PROJECT : A06 - T4 Text Template Code Generation
* FILE : Program.cs
* DATE : 2017/04/23
* DETAILS : This file is our test harness that will test the DAL specific functions.
*   The other cases include some usage with the Repo and Entity.
*   
*   NOTE: It is expected that you have the SQL database and the connection string in App.config
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Configuration;

namespace T4Text
{
    class Program2
    {
        static void Main(string[] args)
        {
            // Create a Repo instance
            Products products = new Products();
            // Create an Entity instance
            Product newProduct = new Product(6, "Pancakes", 9.75m);

            // Get sql connection string from configurations.
            string connStr = ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString;
            // Create DAL instance; pass connection string
            DAL dal = new DAL(connStr);

            Console.WriteLine(">> Getting all the Products from database");
            products = dal.GetAll();
            products.GetAll().ForEach(Console.WriteLine);
            Console.WriteLine();

            Console.WriteLine(">> Adding the Product to database");
            Console.WriteLine(" >> {0}", newProduct.ToString());
            dal.Add(newProduct);
            Console.WriteLine();

            Console.WriteLine(">> Finding the Product in database");
            Console.WriteLine(" >> Product_ID = {0}", newProduct.Product_ID);
            Product foundProduct = dal.Find(6);
            Console.WriteLine(foundProduct.ToString());
            Console.WriteLine();

            Console.WriteLine(">> Re-displaying all Products from database");
            products = dal.GetAll();
            products.GetAll().ForEach(Console.WriteLine);
            Console.WriteLine();

            Product updatedProduct = new Product(6, "Pepperoni Pizza", 10.75m);
            Console.WriteLine(">> Updating the Product in database");
            Console.WriteLine(" >> Product_ID = {0}", updatedProduct.Product_ID);
            Console.WriteLine(updatedProduct.ToString());
            dal.Update(6, updatedProduct);
            Console.WriteLine();

            Console.WriteLine(">> Re-displaying all Products from database");
            products = dal.GetAll();
            products.GetAll().ForEach(Console.WriteLine);
            Console.WriteLine();

            Console.WriteLine(">> Deleting the Product in database");
            Console.WriteLine(" >> Product_ID = {0}", updatedProduct.Product_ID);
            dal.Delete(6);
            Console.WriteLine();

            Console.WriteLine(">> Final displaying of all Products from database");
            products = dal.GetAll();
            products.GetAll().ForEach(Console.WriteLine);
            Console.WriteLine();

            Console.WriteLine("Program has ended . . .");
            Console.ReadKey();
        }
    }
}
