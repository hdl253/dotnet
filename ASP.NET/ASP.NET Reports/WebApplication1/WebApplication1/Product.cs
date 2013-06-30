using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Product(string Name, int Price)
        {
            this.Name = Name;
            this.Price = Price;
        }
    }
    public class Marchant
    {
        public List<Product> Products;
        public Marchant()
        {
            Products = new List<Product>();
            Products.Add(new Product("Pen", 25));
            Products.Add(new Product("Pencil", 30));
            Products.Add(new Product("Notebook", 15));
        }
        public List<Product> GetProducts()
        {
            return Products;
        }
    }
}