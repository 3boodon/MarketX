using System.Collections.Generic;
using MarketX.Models;

namespace MarketX.Tables {
    internal class Users {
        public static List<User> users = new List<User>();
        public static void AddUser(User user) => users.Add(user);
        public static void DeleteUser(string name) => users.Remove(GetUser(name));
        public static User GetUser(string name) => users.Find(user => user.Name == name);
        public static List<User> GetUsers() => users;
        public static bool UserExists(string name, string password) => users.Exists(user => user.Name == name && user.Password == password);
        public static void UpdateUser(string name, string password) {
            User user = GetUser(name);
            user.Password = password;
        }
    }
}
