using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public static class AccountService
    {
        // makes use of the user class properties 
        private static User _user;
        public static void Register(Register model)
        {
            var password = PasswordValidator(model.Password, model.ConfirmPassword);

            _user = new User(model.Birthday)
            {
                FullName = $"{model.LastName} {model.FirstName}",
                Gender = model.Gender,
                Email = model.Email,
                Password = password
            };

            Console.WriteLine($"Congratulations {_user.FullName}! Your registration was successful!");

            bool isLoggedIn = false;
            while (!isLoggedIn)
            {
                isLoggedIn = PromptLogin();
            }
        }

        public static bool PromptLogin()
        {
            Console.WriteLine("Press 1 to login:\n");
            var input = Console.ReadLine().Trim();

            while (input != "1")
            {
                Console.WriteLine("Invalid Input");
                Console.WriteLine("Press 1 to login:\n");
                input = Console.ReadLine().Trim();
            }

            Console.WriteLine("Enter your Email and Password seperated by a space");
            var credentials = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(credentials) && credentials.Split().Length > 1 && credentials.Split().Length < 3)
            {
                var email = credentials.Split()[0].Trim().ToLower();
                var passWord = credentials.Split()[1];
                return ValidateLogin(email, passWord);
            }
            else
            {
                while (string.IsNullOrWhiteSpace(credentials) || !(credentials.Split().Length > 1 && credentials.Split().Length < 3))
                {
                    Console.WriteLine("The field is required!");
                    Console.WriteLine("Please enter your Email and Password seperated by a space");
                    credentials = Console.ReadLine();
                }
                var email = credentials.Split()[0].Trim().ToLower();
                var passWord = credentials.Split()[1];
                return ValidateLogin(email, passWord);
            }
        }

        public static bool ValidateLogin(string email, string password)
        {
            if(_user.Email.ToLower() == email.ToLower() && _user.Password == password)
            {
                _user.ToggleAgePrivacy();
                _user.ToggleAgePrivacy();

                Console.WriteLine($"Welcome, {_user.FullName} Your Age is {_user.Age} Joined: {_user.Created}");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Login Details");
                return false;
            }
        }

        private static string PasswordValidator( string password, string confirmPassword )
        {
            while (password != confirmPassword)
            {
                Console.WriteLine("Password does not match!!");
                Console.WriteLine("Please, enter a password");
                password = Console.ReadLine();
                Console.WriteLine("Please, confirm your password");
                confirmPassword = Console.ReadLine();
            }
            return password;
        }
    }
}
