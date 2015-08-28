using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnityTest.Web.Entities
{
    public class Product
    {
        public Guid ProductID { get; private set; }

        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public Product(string name, decimal price)
        {
            this.ProductID = Guid.NewGuid();
            this.Name = name;
            this.Price = price;
        }

    }
}