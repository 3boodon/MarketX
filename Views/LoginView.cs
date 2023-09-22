
using MarketX.Framework;

namespace MarketX.Views {
    internal class LoginView {
        public static void ShowPage() {
            Helper.Print(Helper.DecoratedText($"Login to {App.Name}", '*'));
            Auth.Login();
        }
    }
}
