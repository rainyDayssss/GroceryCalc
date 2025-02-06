using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryCalc
{
    public class GroceryCalcSystem
    {
        public StockProductInventory StockProductInventory { get; }
        public UserCart UserCart { get; }
        private Decimal totalPriceBeforeDiscount;
        private Decimal totalPrice;
        public Decimal discount;
        public GroceryCalcSystem(UserCart userCart, StockProductInventory stockProductInventory) {
            StockProductInventory = stockProductInventory;
            UserCart = userCart;
            totalPriceBeforeDiscount = 0;
            totalPrice = 0;
            discount = 0;
        }

        public void CalcDiscount() {
            if (totalPriceBeforeDiscount > 500m)
                discount = totalPriceBeforeDiscount * 0.20m; // 20% discount

            else if (totalPriceBeforeDiscount > 200m)
                discount = totalPriceBeforeDiscount * 0.15m; // 15% discount

            else if (totalPriceBeforeDiscount > 100m)
                discount = totalPriceBeforeDiscount * 0.10m; // 10% 
            else
                discount = 0; // no discount
        }

        public Decimal GetDiscount() {
            return discount;
        }

        public void CalcTotalPrice() {
            totalPrice = totalPriceBeforeDiscount - discount;
        }

        public void CalcTotalPriceBeforeDiscount() {
            Decimal temp = 0;
            foreach (Product product in UserCart.Cart)
            {
                temp += product.Price * product.PurchasedQuantity;
            }
            totalPriceBeforeDiscount = temp;
        }

        public Decimal GetTotalPriceBeforeDiscount()
        {
            return totalPriceBeforeDiscount;
        }

        public Decimal GetTotalPrice() {
            return totalPrice;
        }

        public void DisplayTotalPriceBeforeDiscount() {
            Console.WriteLine("Total Price Before Discount: $" + totalPriceBeforeDiscount);
        }

        public void DisplayReceipt() {
            Console.WriteLine("Receipt");
            Console.WriteLine("-------");
            Console.WriteLine("Total Price Before Discount: $" + totalPriceBeforeDiscount);
            Console.WriteLine("Discount: $" + discount); // discount money
            Console.WriteLine("Total Price: $" + totalPrice);
        }

        
    }


}
