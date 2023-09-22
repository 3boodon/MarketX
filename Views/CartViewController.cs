
using System;
using System.Collections.Generic;
using MarketX.Framework;

namespace MarketX.Views {
    internal class CartViewController {
        static bool _isCartEmpty = !(Auth.LoggedInUser.cart.Products.Count > 0);
        public static void ShowPage() {
            Helper.Print(Helper.DecoratedText("Cart Page", '-'));
            // Show the cart table
            if (!_isCartEmpty)
                Table.ShowCartTable(Auth.LoggedInUser.cart.Products);
            // when cart is empty
            else
                Helper.WriteLineIn(ConsoleColor.DarkYellow, "Your cart is empty");

            Helper.Print("Please choose from the menu below", MessageType.INFO);
            OptionsList guestOptions = new OptionsList(new List<Option> {
                    new Option("Add More Products to Cart", () => Router.NavigateTo(RouteName.Products)),
                    new Option("Proceed to Payment",()=>ProceedToPayment()),
                    new Option("Clear Cart", () => new Promise(() => {
                        Auth.LoggedInUser.cart.ClearCart();
                    }).then(() => {
                        Helper.Print("Cart Cleared Successfully", MessageType.SUCCESS);
                        Helper.SetTimeOut(() => Router.NavigateTo(RouteName.Cart), 1000);
                    })),
                    new Option("Go back to Home Page", () => Router.NavigateTo(RouteName.Home)),
                }, () => {
                    Helper.Print("^^Invalid Choice.. Please choose from the list", MessageType.ERROR);
                    Helper.SetTimeOut(() => Router.NavigateTo(RouteName.Home), 1000);
                });
        }

        private static void ProceedToPayment() {
            if (_isCartEmpty)
                Helper.Print("Agaiiiin");
            Router.NavigateTo(RouteName.UnderConstruction);
        }
    }
}
