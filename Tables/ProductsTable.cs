using System.Collections.Generic;
using MarketX.Models;

namespace MarketX.Tables {
    internal static class Products {
        public static List<Product> products = new List<Product>();

        public static void AddProduct(Product product) =>
            products.Add(product);

        public static void RemoveProduct(Product product) =>
            products.Remove(product);

        public static void UpdateProduct(Product product) =>
            products[products.IndexOf(product)] = product;

        public static Product GetProductById(int id) =>
            products.Find(product => product.Id == id);

        public static List<Product> GetAllProducts() => products;

        public static List<Product> GetProductsByName(string name) =>
            products.FindAll(product => product.Name == name);

        public static void FillProductsList() {
            Product.Count = 0; // to prevent the count from incrementing every time we create a new instance of Product
            products = new List<Product> {
                new Product("Iphone 11", 1000),
                new Product("Iphone 12", 1200),
                new Product("Iphone 12 Pro", 1500),
                new Product("Iphone 12 Mini", 900),
                new Product("Iphone 11 Pro", 1300),
                new Product("Iphone 11 Mini", 800),
                new Product("Iphone X", 800),
                new Product("Iphone XS", 900),
                new Product("Iphone XS Max", 1000),
                new Product("Iphone XR", 700),
                new Product("Iphone 8", 500),
                new Product("Iphone 8 Plus", 600),
                new Product("Iphone 7", 400),
                new Product("Iphone 7 Plus", 500),
                new Product("Iphone 6", 300),
                new Product("Iphone 6 Plus", 400),
                new Product("Iphone 6s", 350),
                new Product("Iphone 6s Plus", 450),
                new Product("Iphone SE", 200),
            };
        }
    }
}
