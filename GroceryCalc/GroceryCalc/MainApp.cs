using System;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;

namespace GroceryCalc
{
    public class MainApp
    {
        static void Main(string[] args)
        {
            // Initializes the inventory, User Cart, and Grocery Discounr Calculator 
            StockProductInventory inventory = new StockProductInventory();
            UserCart userCart;
            GroceryCalcSystem groceryCalc;

            inventory.AddProduct(1, "Apple", 1.0m);
            inventory.AddProduct(2, "Brush", 5.05m);
            inventory.AddProduct(3, "Mirror", 3.20m);
            inventory.AddProduct(4, "Pen", 11.06m);
            inventory.AddProduct(5, "Bag", 110.08m);

            Console.WriteLine("\nWelcome to the Grocery Store!");
            Console.WriteLine("-----------------------------");

            bool isExit = false;
            while (!isExit) {
                Console.Write("Do you want to make a new purchase? (y/n): ");
                string input = Console.ReadLine().ToLower().Trim();

                if (input == "y") {
                    // creates a new Cart and Calc objects for the new purchase
                    userCart = new UserCart();
                    groceryCalc = new GroceryCalcSystem(userCart, inventory);
                    bool isExitInner = false;
                    while (!isExitInner) {
                        try
                        {
                            Console.WriteLine("\nAvailable Products:");
                            inventory.DiplayAllProducts();

                            Console.Write("Enter the number of the product you want to purchase: ");
                            int productChoice = int.Parse(Console.ReadLine());

                            Product p = inventory.GetProductById(productChoice);
                            if (p == null) {
                                throw new Exception("Product was not found...");
                            }

                            Console.Write("Enter quantity: ");
                            int quantity = int.Parse(Console.ReadLine());

                            userCart.AddProduct(p, quantity);

                            userCart.DisplayAllProducts();


                            // Calculations
                            groceryCalc.CalcTotalPriceBeforeDiscount();
                            groceryCalc.DisplayTotalPriceBeforeDiscount();


                            Console.Write("Do you want to add another item? (y/n): ");
                            string response = Console.ReadLine().ToLower().Trim();

                            if (response == "n")
                                isExitInner = true;
                            else if (response == "y")
                                continue;
                            else
                                throw new Exception();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Please enter a valid input...");
                        }
                    }


                    // Display receipt
                    Console.Clear();

                    groceryCalc.CalcTotalPriceBeforeDiscount();
                    groceryCalc.CalcDiscount();
                    groceryCalc.CalcTotalPrice();

                    groceryCalc.DisplayReceipt();

                }
                else if (input == "n") {
                    isExit = true;
                    Console.WriteLine("Thank you for shopping with us! Goodbye!");
                }
                else
                    Console.WriteLine("Please enter a valid input...");


            }
        }
    }
}