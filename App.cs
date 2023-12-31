﻿using System;
using MarketX.Framework;

namespace MarketX {
    internal static class App {
        static public string Name = "Market X";

        public static void Run() {
            // Go to home page
            Router.NavigateTo(RouteName.Home);
        }

        public static void Close() {
            Console.Clear();
            Helper.Print(Helper.DecoratedText($"Thanks For Using {Name}, Have a nice day", '*'));
            Helper.Print("Press any key to exit");
            Console.ReadKey();
        }
    }
}
