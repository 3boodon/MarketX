using MarketX.Framework;
using MarketX.Models;
using MarketX.Tables;

namespace MarketX.Views {
    internal class ProductViewController {
        public static void ShowPage() {
            Helper.Print("Add any product to the cart using its ID number: ", MessageType.INFO);

            // fill the products list
            Products.FillProductsList();

            //show the products table
            Table.ShowProductsTable(Products.GetAllProducts());

            //get the product id from the user
            int productId = Helper.GetUserInputAsInt("Enter Product ID or 0 to go back to Home Page: ");

            // check if the user wants to go back to the home page
            if (productId == 0)
                Router.NavigateTo(RouteName.Home);
            //get the selected product
            Product selectedProduct = Products.GetProductById(productId);

            //check if the selected product exists
            if (selectedProduct == null) {
                Helper.Print("Product Not Found..!", MessageType.ERROR);
                Helper.Print("Make sure to choose a valid ID from the list", MessageType.INFO);
                Helper.SetTimeOut(() => Router.NavigateTo(RouteName.Products), 1000);
            }
            else {
                //get the quantity from the user
                int requestedQuantity = Helper.GetUserInputAsInt($"How many {selectedProduct.Name} do you want ?: ");

                //add the product to the cart
                Auth.LoggedInUser.cart.AddProduct(selectedProduct, requestedQuantity);

                //show a success message
                Helper.Print("Adding products to your cart ... please wait", MessageType.INFO);
                Helper.SetTimeOut(() =>
                    Helper.Print($"{requestedQuantity} {selectedProduct.Name} have been added successfully to your cart", MessageType.SUCCESS),
                1000);

                //redirect to the products page
                Helper.SetTimeOut(() => Router.NavigateTo(RouteName.Products), 2000);
            }
        }
    }
}
