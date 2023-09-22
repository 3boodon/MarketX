using System;
using System.Collections.Generic;
using MarketX.Models;
using MarketX.Tables;

namespace MarketX.Framework {
    internal class Table {

        public static void ShowProductsTable(List<Product> products) {
            Helper.Print(Helper.DecoratedText("Products Table", '.'));

            // Header
            Helper.WriteLineIn(ConsoleColor.Yellow, "\nId\tName\t\t\t\tPrice");
            Helper.Print(Helper.Repeat('-', 45));

            // Body
            foreach (Product product in products) {
                Helper.Print($"{product.Id}\t{product.Name}\t\t\t{product.Price}$");
            }

            // Footer
            int totalProducts = Products.GetAllProducts().Count;
            Helper.Print(Helper.Repeat('-', 45));
            Helper.WriteLineIn(ConsoleColor.DarkYellow, $"Total Available Products => {totalProducts}\n");

        }

        public static void ShowCartTable(List<CartItem> cartItems) {
            Helper.Print(Helper.DecoratedText("Cart Items Table", '.'));
            // Header 
            Helper.WriteLineIn(ConsoleColor.Yellow, "\nId\tProduct Name\t\t\tQuantity\tPrice");
            Helper.Print(Helper.Repeat('-', 65));

            // Body
            foreach (CartItem cartItem in cartItems) {
                Helper.Print($"{cartItem.Id}\t{cartItem.Product.Name}\t\t\t{cartItem.Quantity}\t\t{cartItem.Product.Price * cartItem.Quantity}$");
            }

            // Footer
            decimal totalPrice = Auth.LoggedInUser.cart.TotalPrice(cartItems);
            Helper.Print(Helper.Repeat('-', 65));
            Helper.WriteLineIn(ConsoleColor.DarkYellow, $"Total Price {totalPrice}$ \n");
        }

        public static void ShowUsersTable(List<User> users) {
            Helper.Print(Helper.DecoratedText("Users Table", '.'));

            // Header
            Helper.Print("\nId\tName\tPassword");

            // Body
            foreach (User user in users) {
                Helper.Print($"{user.Id}\t{user.Name}\t{Helper.Repeat('*', user.Password.Length)}\n");
            }
        }
    }
}
