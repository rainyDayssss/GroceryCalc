using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryCalc
{
    public class StockProductInventory
    {
        private List<Product> stockProducts;

        public StockProductInventory() {
            stockProducts = new List<Product>();
        }

        public void AddProduct(int id, String name, Decimal price) {
            stockProducts.Add(new Product(id, name, price));
        }

        public void RemoveProductByName(String name) { 
            // TODO 
        }

        public Product? GetProductById(int id) {
            foreach (Product product in stockProducts)
            {
                if (id == product.Id)
                    return product;
            }

            return null;
        }

        public void DiplayAllProducts() {
            foreach (Product product in stockProducts) {
                Console.WriteLine(product.Id + ". Name: " + product.Name + " Price: $" + product.Price);
            }
        }

        
    }
}
