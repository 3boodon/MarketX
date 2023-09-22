using System;
using System.Threading;

namespace MarketX.Framework {
    internal static class Helper {
        // get user input as string value
        public static string GetUserInput(string prompt) {
            WriteLineIn(ConsoleColor.Cyan, prompt);
            return Console.ReadLine();
        }

        // get user input as int value
        public static int GetUserInputAsInt(string prompt) {
            WriteLineIn(ConsoleColor.Cyan, prompt);
            try {
                int integerInput = int.Parse(Console.ReadLine());
                return integerInput;
            }
            catch (Exception e) {
                Print(e.Message, MessageType.ERROR);
                Print("Please enter a valid integer value", MessageType.INFO);
                return GetUserInputAsInt(prompt);
            }
        }

        // do something after a certain amount of time (in milliseconds)
        public static void SetTimeOut(Action callback, int milliseconds = 2000) {
            Thread.Sleep(milliseconds);
            callback();
        }

        // print a message with a color based on the message type
        public static void Print<T>(T message, MessageType messageType = MessageType.Normal) {
            switch (messageType) {
                case MessageType.ERROR:
                    Audio.Play("Error");
                    WriteLineIn(ConsoleColor.Red, message);
                    break;
                case MessageType.SUCCESS:
                    Audio.Play("Success");
                    WriteLineIn(ConsoleColor.Green, message);
                    break;
                case MessageType.INFO:
                    WriteLineIn(ConsoleColor.Blue, message);
                    break;
                case MessageType.WARNING:
                    Audio.Play("Warning");
                    WriteLineIn(ConsoleColor.Yellow, message);
                    break;
                default:
                    WriteLineIn(ConsoleColor.DarkGray, message);
                    break;
            }
        }


        //Print a greeting message to the user depending on the time of the day
        public static string GreetingMessageDependingOnTheTimeOfTheDay() {
            DateTime now = DateTime.Now;
            int currentHour = now.Hour;
            string greeting = currentHour > 0 && currentHour < 12 ? "Morning" : "Evening";
            return $"Good {greeting} {Auth.LoggedInUser.Name}!";
        }

        // print a message with a color
        public static void WriteLineIn<T>(ConsoleColor color, T message) {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }


        // repeat a string n times
        public static string Repeat(char message, int count) => new string(message, count);

        // print a message with a decoration
        public static string DecoratedText(string message, char symbol = '-') {
            return $"{Repeat(symbol, message.Length)}\n{message}\n{Repeat(symbol, message.Length)}";
        }


    }


    enum MessageType {
        Normal,
        ERROR,
        SUCCESS,
        INFO,
        WARNING
    }
}
