/*
 * PROJECT : T4 Template Test
 * FILE : Product.cs
 * DATE 2017/04/22
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace T4Test
{
    public class Product
    {
        public int Product_ID { get; set; }
        public string Description { get; set; }
        public decimal Unit_Price { get; set; }

        public Product()
        {

        }

        public Product(int product_id, string description, decimal unit_price)
        {
            Product_ID = product_id;
            Description = description;
            Unit_Price = unit_price;
        }


        public override string ToString()
        {
            return Product_ID + " " + Description + " " + Unit_Price;
        }
    }
}
