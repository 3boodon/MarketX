using System.Collections.Generic;

namespace MarketX.Models {
    internal class Cart {
        public static Cart Instance { get; set; }
        public List<CartItem> Products { get; set; }
        public User User { get; set; }

        public Cart(User user) {
            this.User = user;
            this.Products = new List<CartItem>();
        }

        public void AddProduct(Product product, int Quantity) {
            CartItem recievedProduct = new CartItem(product, Quantity);
            this.Products.Add(recievedProduct);
        }

        public decimal TotalPrice(List<CartItem> cartItems) {
            decimal totalPrice = 0;
            foreach (CartItem cartItem in cartItems) {
                totalPrice += cartItem.Product.Price * cartItem.Quantity;
            }
            return totalPrice;
        }

        public void RemoveProduct(int productId) {
            CartItem selectedProduct = this.Products.Find(product => product.Id == productId);
            this.Products.Remove(selectedProduct);
        }

        public void ClearCart() {
            this.Products.Clear();
        }
    }

    class CartItem {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public CartItem(Product product, int quantity) {
            this.Id++;
            this.Product = product;
            this.Quantity = quantity;
        }
    }

}
