
using System;
using System.Collections.Generic;
using MarketX.Framework;

namespace MarketX.Views {
    internal class UnderConstructionViewController {
        public static void ShowPage() {

            Helper.Print(Helper.DecoratedText("This Page is Still Under Construction", '*'));
            Helper.Print("Please choose from the menu below", MessageType.INFO);

            // To be shown when the user is logged in
            OptionsList guestOptions = new OptionsList(new List<Option> {
                    new Option("Go Back Home",()=> Router.NavigateTo(RouteName.Home)),
                    new Option("Enjoy Listening to some music ^_^", PlayMusic),
                    new Option("Exit", () => App.Close())
                }, () => {
                    Helper.Print("^^Invalid Choice.. Please choose from the list", MessageType.ERROR);
                    Helper.SetTimeOut(() => Router.NavigateTo(RouteName.UnderConstruction), 1000);
                });

        }

        private static void PlayMusic() {
            new Promise(() => Audio.Play("Amelie")).then(() => {
                Helper.Print("Yann Tiersen - Amelie _ Piano Cover - It will start now .. ENJOY !", MessageType.SUCCESS);
                Audio.Play("Amelie");
                Helper.Print("Press any key to go back");
                Console.ReadKey();
                Router.NavigateTo(RouteName.UnderConstruction);
            });
        }
    }
}
