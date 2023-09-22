using System;
using System.Collections.Generic;
using MarketX.Views;

namespace MarketX.Framework {
    internal class Router {
        // Define all routes here
        public static List<Route> routes = new List<Route> {
            // Home Routes
            DefineNewRoute(RouteName.Home,HomeViewController.ShowPage),
            DefineNewRoute(RouteName.UnderConstruction,UnderConstructionViewController.ShowPage),

            // Ecommerce Routes
            DefineNewRoute(RouteName.Products,ProductViewController.ShowPage),
            DefineNewRoute(RouteName.Cart,CartViewController.ShowPage),

            // Authintication Routes
            DefineNewRoute(RouteName.Login,LoginView.ShowPage),
            DefineNewRoute(RouteName.Register,RegisterView.ShowPage),
            DefineNewRoute(RouteName.Logout,Auth.Logout),

    };

        // Define a new route
        public static Route DefineNewRoute(RouteName name, Action callback = null) {
            return new Route(name, callback);
        }

        // Navigate to a route by its name
        public static void NavigateTo(RouteName routeName) {
            // Find the route by its name
            Route route = routes.Find(theRoute => theRoute.name == routeName);
            if (route != null) {
                // If the route is found, clear the console and run the callback
                Console.Title = $"{routeName} - {App.Name}";
                Console.Clear();
                route.callback();
            }
            else {
                // If the route is not found, redirect to home page
                Console.Title = $"{routeName} - 404 NOT FOUND";
                Helper.Print("Route Not Found, You will be redirected to Home Page ..", MessageType.ERROR);
                Helper.SetTimeOut(() => NavigateTo(RouteName.Home), 1000);
            }
        }
    }


    class Route {
        public RouteName name;
        public Action callback;
        public Route(RouteName name, Action callback) {
            this.name = name;
            this.callback = callback;
        }
    }

    // This enum is created for better readability and to avoid typos
    enum RouteName {
        // Home Routes
        Home,
        UnderConstruction,
        // Ecommerce Routes
        Products,
        Cart,
        Payment,

        // Authintication Routes
        Login,
        Register,
        Logout
    }
}
