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

            Console.WriteLine("Press 1 to login:\n");
            var input = Console.ReadLine();

            if(input == "1")
            {
                Console.WriteLine("Enter your Email and password seperated with space");
                var credentials = Console.ReadLine();
                if ( !string.IsNullOrWhiteSpace(credentials) && credentials.Split().Length > 1 && credentials.Split().Length < 3 )
                {
                    var email = credentials.Split()[0].Trim().ToLower();
                    var passWord = credentials.Split()[1];
                    Login(email, passWord);
                }
                else
                {
                    while (string.IsNullOrWhiteSpace(credentials) || !(credentials.Split().Length > 1 && credentials.Split().Length < 3))
                    {
                        Console.WriteLine("The field is required!");
                        Console.WriteLine("Enter your Email and password seperated with space");
                        credentials = Console.ReadLine();
                    }
                    var email = credentials.Split()[0].Trim().ToLower();
                    var passWord = credentials.Split()[1];
                    Login(email, passWord);
                }
            } 
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }

        public static void Login(string email, string password)
        {
            if(_user.Email.ToLower() == email.ToLower() && _user.Password == password)
            {
                _user.ToggleAgePrivacy();
                _user.ToggleAgePrivacy();

                Console.WriteLine($"Welcome, {_user.FullName} Your Age is {_user.Age} Joined: {_user.Created}");
            }
            else
            {
                Console.WriteLine("Invalid Login Details");
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
