/*
* FILE : Products.cs
* DATE : 2017/04/23
* DETAILS : Generated code for the Products class.
*/
using System;
using System.Collections.Generic;

namespace T4Text
{
    public class Products
    {
        private List<Product> ProductsList = new List<Product>();

        /// <summary>
        /// Default constructor
        /// </summary>
        public Products()
        {

        }

        /// <summary>
        /// Get all the Products
        /// </summary>
        public List<Product> GetAll()
        {
            return ProductsList;
        }

        /// <summary>
        /// Add Product to repo
        /// </summary>
        public void Add(Product p)
        {
            ProductsList.Add(p);
        }

        /// <summary>
        /// Delete Product from repo
        /// </summary>
        public void Delete(int product_id)
        {
            foreach (Product p in ProductsList)
            {
                if (p.Product_ID == product_id)
                {
                    ProductsList.Remove(p);
                    break;
                }
            }
        }

        /// <summary>
        /// Find Product from repo
        /// </summary>
        public Product Find(int product_id)
        {
            Product product = null;

            foreach (Product p in ProductsList)
            {
                if (p.Product_ID == product_id)
                {
                    product = p;
                    break;
                }
            }

            return product;
        }

        /// <summary>
        /// Update Product in repo
        /// </summary>
        public void Update(int product_id, Product product)
        {
            foreach (Product p in ProductsList)
            {
                if (p.Product_ID == product_id)
                {
                    p.Product_ID = product.Product_ID;
                    p.Description = product.Description;
                    p.Unit_Price = product.Unit_Price;
                    break;
                }
            }
        }
    }
}


