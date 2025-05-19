using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PizzaApp
{
    internal class User
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;

        public string GetValidationError()
        {
            if (string.IsNullOrWhiteSpace(Email) || !Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return "Enter a valid email.";

            if (string.IsNullOrWhiteSpace(Password) || Password.Length < 8)
                return "Password must be at least 8 characters long.";

            if (ConfirmPassword != Password)
                return "Passwords do not match.";

            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 || !Regex.IsMatch(Username, @"^[a-zA-Z0-9]+$"))
                return "Username must be at least 3 characters long and contain only letters and numbers.";

            return null;
        }
    }
}


