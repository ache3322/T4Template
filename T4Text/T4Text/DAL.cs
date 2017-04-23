/*
* FILE : DAL.cs
* DATE : 2017/04/23
* DETAILS : Generated code for the DAL class.
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace T4Text
{
    public class DAL
    {
        public string Connection { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public DAL()
        {
        }

        /// <summary>
        /// Constructor takes in a connection string.
        /// </summary>
        public DAL(string conn)
        {
            Connection = conn;
        }

        /// <summary>
        /// Get all the rows and columns from the database.
        /// </summary>
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

        /// <summary>
        /// Find the Product from the database
        /// </summary>
        public Product Find(int product_id)
        {
            Product product = new Product();

            SqlConnection conn = new SqlConnection(Connection);
            SqlCommand cmd = new SqlCommand();

            string find = "SELECT * FROM Product WHERE Product_ID=" + product_id;

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

        /// <summary>
        /// Adding a new Product to the database
        /// </summary>
        public void Add(Product p)
        {
            SqlConnection conn = new SqlConnection(Connection);
            SqlCommand cmd = new SqlCommand();

            string insert = "INSERT INTO Product(Product_ID,Description,Unit_Price) VALUES(" +
                p.Product_ID + "," + "'" + p.Description + "'" + "," + p.Unit_Price
                + ")";

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

        /// <summary>
        /// Deleting a Product from the database
        /// </summary>
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

        /// <summary>
        /// Update the Product in the database
        /// </summary>
        public void Update(int product_id, Product product)
        {
            SqlConnection conn = new SqlConnection(Connection);
            SqlCommand cmd = new SqlCommand();

            string set_clause = "Description=" + "'" + product.Description + "'" + "," + "Unit_Price=" + product.Unit_Price;

            string update = "UPDATE Product "
                + "SET " + set_clause
                + "WHERE Product_ID=" + product_id;

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

