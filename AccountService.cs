using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public static class AccountService
    {
        // make use of the user class properties 
        private static User _user;
        public static void Register(Register model)
        {
            var password = PasswordValidator(model.Password, model.ConfirmPassword);

            if (string.IsNullOrWhiteSpace(password)) 
                Console.WriteLine("Password Does not match!!");
            
            _user = new User(model.Birthday)
            {
                FullName = $"{model.LastName} {model.FirstName}",
                Gender = model.Gender,
                Email = model.Email,
                Password = password

            };

            //Instantiate a class with parameterless constructor

            // _user = new User
            // {
            //     FullName = $"{model.LastName} {model.FirstName}",
            //     Birthday = new DateTime(1993, 12, 5),
            //     Gender = model.Gender,
            //     Email = model.Email,
            //     Password = password
            // };

            Console.WriteLine($"Congratulations!, {_user.FullName} your registration was successful!");

            Console.WriteLine("Press 1 to login:\n");
            var input = Console.ReadLine();

            if(input == "1")
            {
                Console.WriteLine("Enter your Email and password seperated with space");
                var credentials = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(credentials))
                {
                    var email = credentials.Split()[0].Trim().ToLower();
                    var passWord = credentials.Split()[1];
                    Login(email, passWord);
                } else
                {
                    Console.WriteLine("The field is required!");
                }
                
            } else
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

        private static string PasswordValidator( string password, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
                return string.Empty;

            return password.Trim() == confirmPassword.Trim() ? password : string.Empty;
           
        }
    }
}
