using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GroceryCalc
{
    public class UserCart
    {
        public List<Product> Cart { get; }

        public UserCart() {
            Cart = new List<Product>();
        }

        public void AddProduct(String name, Decimal price, int quantity) {

            foreach (Product product in Cart)
            {
                if (product.Name.Equals(name))
                {
                    product.PurchasedQuantity += quantity;
                    return;
                }
            }

            Cart.Add(new Product(name, price, quantity));
        }

        public void AddProduct(Product product, int quantity) {
            AddProduct(product.Name, product.Price, quantity);
        }

        public void DisplayAllProducts() {
            foreach (Product product in Cart)
            {
                Console.WriteLine("Product Name: " + product.Name + " Price: $" + product.Price + " Quantity: " + product.PurchasedQuantity);
            }
        }



    }
}
