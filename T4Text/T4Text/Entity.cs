/*
* FILE : Product.cs
* DATE : 2017/04/23
* DETAILS : Generated code for the Product class.
*/
using System;

namespace T4Text
{
    public class Product
    {
        public int Product_ID { get; set; }
        public string Description { get; set; }
        public decimal Unit_Price { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Product()
        {

        }

        /// <summary>
        /// Constructor containing 3 arguments
        /// </summary>
        public Product(int product_id, string description, decimal unit_price)
        {
            this.Product_ID = product_id;
            this.Description = description;
            this.Unit_Price = unit_price;
        }


        /// <summary>
        /// Overriding the ToString() method
        /// </summary>
        public override string ToString()
        {
            return Product_ID + " " + Description + " " + Unit_Price;
        }
    }
}
