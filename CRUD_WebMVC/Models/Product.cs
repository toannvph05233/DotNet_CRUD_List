using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_WebMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
       
        public Product(int Id, string Name, double Price)
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
        }
        public Product() { }
    }
}