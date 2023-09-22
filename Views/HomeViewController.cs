using System.Collections.Generic;
using MarketX.Framework;

namespace MarketX.Views {
    internal class HomeViewController {
        public static void ShowPage() {
            if (Auth.IsLoggedIn) {
                Helper.Print(Helper.DecoratedText(Helper.GreetingMessageDependingOnTheTimeOfTheDay(), '*'));
                Helper.Print("Please choose from the menu below", MessageType.INFO);
                // To be shown when the user is logged in
                OptionsList userOptions = new OptionsList(new List<Option> {
                    new Option("Add Products To Cart", () => Router.NavigateTo(RouteName.Products)),
                    new Option("Open Cart", () => Router.NavigateTo(RouteName.Cart)),
                    new Option("Logout", () => Router.NavigateTo(RouteName.Logout)),
                    new Option("Exit", () => App.Close())
                }, () => {
                    Helper.Print("^^Invalid Choice.. Please choose from the list", MessageType.ERROR);
                    ShowPage();
                });
            }
            else {
                Helper.Print(Helper.DecoratedText($"Welcome to {App.Name}", '*'));
                Helper.Print("Please choose from the menu below", MessageType.INFO);

                // To be shown when the user is not logged in
                OptionsList guestOptions = new OptionsList(new List<Option> {
                    new Option("Login", () => Router.NavigateTo(RouteName.Login)),
                    new Option("Create a New Account", () => Router.NavigateTo(RouteName.Register)),
                    new Option("Exit", () => App.Close())
                }, () => {
                    Helper.Print("^^Invalid Choice.. Please choose from the list", MessageType.ERROR);
                    Helper.SetTimeOut(() => Router.NavigateTo(RouteName.Home), 1000);
                });

            }
        }

    }
}
