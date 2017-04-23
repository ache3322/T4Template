/*
 * PROJECT : T4 Template Test
 * FILE : Products.cs
 * DATE 2017/04/22
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace T4Test
{
    public class Products
    {
        private List<Product> ProductList = new List<Product>();


        public Products()
        {

        }


        public List<Product> GetAll()
        {
            return ProductList;
        }


        public Product Find(int product_id)
        {
            Product product = null;

            foreach(Product p in ProductList)
            {
                if (p.Product_ID == product_id)
                {
                    product = p;
                    break;
                }
            }

            return product;
        }


        public void Add(Product p)
        {
            ProductList.Add(p);
        }




        public void Delete(Product p)
        {
            ProductList.Remove(p);
        }


        public void Update(int product_id, Product product)
        {
            foreach (Product p in ProductList)
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


        public void Delete(int product_id)
        {
            foreach (Product p in ProductList)
            {
                if (p.Product_ID == product_id)
                {
                    ProductList.Remove(p);
                    break;
                }
            }
        }
    }
}
