using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryCalc
{
    
    public class Product
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public Decimal Price { get; set; }
        public int PurchasedQuantity { get; set; }

        public Product(int id, String name, Decimal price)
        {
            Name = name;
            Price = price;
            PurchasedQuantity = 0; // zero for the intial choosing of product
            Id = id;
        }

        public Product(String name, Decimal price, int quantity)
        {
            Name = name;
            Price = price;
            PurchasedQuantity = quantity; 
        }
    }
}
