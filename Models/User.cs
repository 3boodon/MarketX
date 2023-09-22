namespace MarketX.Models {
    internal class User {
        static int Count;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Cart cart { get; set; }

        public User(string name, string password) {
            Count++;
            this.Id = Count;
            this.Name = name;
            this.Password = password;
            this.cart = new Cart(this);
        }
    }
}
