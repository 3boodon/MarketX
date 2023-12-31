﻿using System;
using MarketX.Framework;
using MarketX.Models;
using MarketX.Tables;

namespace MarketX {
    internal class Auth {
        public static bool IsLoggedIn { get; set; }
        public static User LoggedInUser { get; set; }
        public static User LoggedOutUser { get; set; }

        public static void Login() {
            // get user input for username and password
            string username = Helper.GetUserInput("Enter your username");
            string password = Helper.GetUserInput("Enter your password");


            // check if user doesn't exist
            if (!Users.UserExists(username, password)) {
                Helper.Print(Helper.DecoratedText("Invalid username or password"), MessageType.WARNING);
                string userInput = null;
                bool isInvalidInput = userInput != "y" || userInput != "n";
                do {
                    userInput = Helper.GetUserInput("Wanna Try Again ? (Y / N)").ToLower();
                    switch (userInput) {
                        case "y":
                            Router.NavigateTo(RouteName.Login);
                            break;
                        case "n":
                            Router.NavigateTo(RouteName.Home);
                            break;
                        default:
                            Helper.Print("Invalid Choice", MessageType.WARNING);
                            break;
                    }
                } while (isInvalidInput);
            }

            // set logged in status to true
            IsLoggedIn = true;

            // set logged in user
            LoggedInUser = Users.GetUser(username);
            Helper.Print(Helper.DecoratedText($"Welcome Back {LoggedInUser.Name}"), MessageType.INFO);

            // Clear Console after 2 seconds
            Helper.SetTimeOut(() => Router.NavigateTo(RouteName.Home), 2000);
        }

        public static void Register() {

            // get user input for username and password
            string username = Helper.GetUserInput("Create a username");
            Helper.Print($"Your password must be at least 6 characters long, and contain at least 1 lower case charachter, 1 upper case character and 1 at least one digit{username}", MessageType.INFO);
            string password;
            do {
                password = Helper.GetUserInput("Create a password");
            } while (!password.IsValidPassword());

            // create a new user
            User user = new User(username, password);
            Users.AddUser(user);


            //Clear Console
            Console.Clear();
            Helper.Print(Helper.DecoratedText("Your account has been Created Successfully", '-'), MessageType.SUCCESS);
            Helper.Print("You will be redirected to the login page in a few moments ....");

            // redirect user to login
            Helper.SetTimeOut(() => Router.NavigateTo(RouteName.Login), 2500);
        }

        public static void Logout() {
            IsLoggedIn = false;
            LoggedOutUser = LoggedInUser;
            LoggedInUser = null;
            Helper.Print($"Logged Out Successfully.. See you soon {LoggedOutUser.Name}", MessageType.WARNING);
            Helper.SetTimeOut(() => Router.NavigateTo(RouteName.Home), 2000);
        }
    }
}
