
using MarketX.Framework;

namespace MarketX.Views {
    internal class RegisterView {
        public static void ShowPage() {
            Helper.Print(Helper.DecoratedText($"Create new account", '*'));
            Auth.Register();
        }
    }
}
