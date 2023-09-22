using MarketX.Tables;

namespace MarketX.Models {
    internal class Product {
        public static int Count;
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price) {
            Count++;
            this.Id = Count;
            this.Name = name;
            this.Price = price;
            Products.AddProduct(this);
        }
    }
}
