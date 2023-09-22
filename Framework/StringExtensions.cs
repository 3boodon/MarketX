using System;
using System.Text.RegularExpressions;

namespace MarketX.Framework {
    internal static class StringExtensions {
        public static bool IsValidPassword(this string input) {
            Regex requiredLength = new Regex("^.{6,}$"); // Matches 6 Charachters or more
            Regex lowerCase = new Regex("^.*(?=.*[a-z])[a-z]{1,}.*$"); // Matches 1 or more lower case charachters 
            Regex upperCase = new Regex("^.*(?=.*[A-Z])[A-Z]{1,}.*$"); // Matches 1 or more upper case charachters 
            Regex digits = new Regex("^.*(?=.*\\d)[\\d]{1,}.*$"); // Matches 1 or more digits 

            try {
                if (!lowerCase.IsMatch(input))
                    throw new Exception("Password must contain at least 1 lower case charachter");
                if (!upperCase.IsMatch(input))
                    throw new Exception("Password must contain at least 1 upper case charachter");
                if (!digits.IsMatch(input))
                    throw new Exception("Password must contain at least 1 digit");
                if (!requiredLength.IsMatch(input))
                    throw new FormatException("Password length Must be 6 or more");
                return true;
            }
            catch (Exception e) {
                Helper.Print(e.Message, MessageType.ERROR);
                return false;
            }
        }
    }
}
