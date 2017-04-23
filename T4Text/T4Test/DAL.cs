/*
 * PROJECT : T4 Template Test
 * FILE : DAL.cs
 * DATE 2017/04/22
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace T4Test
{
    public class DAL
    {
        public string Connection { get; set; }


        public DAL()
        {

        }

        public DAL(string conn)
        {
            Connection = conn;
        }

        public Products GetAll()
        {
            Products products = new Products();

            SqlConnection conn = new SqlConnection(Connection);
            SqlCommand cmd = new SqlCommand();

            string query = "SELECT * FROM Product";

            cmd.Connection = conn;
            cmd.CommandText = query;

            try
            {
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Product product = new Product();

                    product.Product_ID = (int)dr["Product_ID"];
                    product.Description = (string)dr["Description"];
                    product.Unit_Price = (decimal)dr["Unit_Price"];

                    products.Add(product);
                }

                products.GetAll().ForEach(Console.WriteLine);

                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return products;
        }

        public Product Find(int product_id)
        {
            Product product = new Product();
            SqlConnection conn = new SqlConnection(Connection);
            SqlCommand cmd = new SqlCommand();

            string find = "SELECT * Product WHERE product_id=" + product_id;

            cmd.Connection = conn;
            cmd.CommandText = find;

            try
            {
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    product.Product_ID = (int)dr["Product_ID"];
                    product.Description = (string)dr["Description"];
                    product.Unit_Price = (decimal)dr["Unit_Price"];
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return product;
        }

        public void Add(Product p)
        {
            SqlConnection conn = new SqlConnection(Connection);
            SqlCommand cmd = new SqlCommand();

            string insert = "INSERT INTO Product(Description, Unit_Price) VALUES("
                + "'" + p.Description + "'" + ","
                + p.Unit_Price + ")";

            cmd.Connection = conn;
            cmd.CommandText = insert;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void Delete(int product_id)
        {
            SqlConnection conn = new SqlConnection(Connection);
            SqlCommand cmd = new SqlCommand();

            string delete = "DELETE FROM Product WHERE Product_ID=" + product_id;

            cmd.Connection = conn;
            cmd.CommandText = delete;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void Update(int product_id, Product product)
        {
            SqlConnection conn = new SqlConnection(Connection);
            SqlCommand cmd = new SqlCommand();

            string set = "Description=" + product.Description + ","
                + "Unit_Price=" + product.Unit_Price;

            string update = "UPDATE Product"
                + "SET " + set
                + "WHERE product_id=" + product_id;

            cmd.Connection = conn;
            cmd.CommandText = update;

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
