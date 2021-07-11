using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public static class Application
    {
        public static void Run()
        {
            var menu = new StringBuilder();
            menu.Append("Hello, welcome to my App:\n");
            menu.AppendLine("Enter your FirstName");
            Console.WriteLine(menu.ToString());
            var firstName = Console.ReadLine().Trim();
            
            while (string.IsNullOrWhiteSpace(firstName) || firstName.Split().Length > 1)
	        {
                firstName = PromptUser("first name");
	        }	        

            Console.WriteLine("Enter Lastname");
            var lastName = Console.ReadLine().Trim();

            while (string.IsNullOrWhiteSpace(lastName) || lastName.Split().Length > 1)
	        {
                lastName = PromptUser("last name");
	        }

            Console.WriteLine("Enter email");
            var email = Console.ReadLine().Trim();
            
            while (string.IsNullOrWhiteSpace(email) || email.Split().Length > 1)
	        {
                email = PromptUser("email");
	        }

            Console.WriteLine("Enter birthday");
            var birthday = Console.ReadLine().Trim();
            
            // TryParse() converts the string representation to equivalent DateTime object
            DateTime birthdayValue;
            while (string.IsNullOrWhiteSpace(birthday) || !(DateTime.TryParse(birthday, out birthdayValue)))
	        {
                birthday = PromptUser("birthday");
	        }
                        
            Console.WriteLine("Select your Gender: \n1. Male \n2. Female \n3. Prefer not to say");
            var gender = Console.ReadLine().Trim();
            
            while (string.IsNullOrWhiteSpace(gender) || (gender != "1" && gender != "2" && gender != "3"))
	        {
                Console.WriteLine("Invalid Gender Selection");
                Console.WriteLine("Select your Gender using the number key: \n1. Male \n2. Female \n3. Prefer not to say");
                gender = Console.ReadLine().Trim();
	        }

            var selectedGender = GenderSelection(gender);

            Console.WriteLine("Enter Password");
            var password = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine($"Please, enter a password");
                password = Console.ReadLine();
            }

            Console.WriteLine("Confirm Password");
            var confirmPassword = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(confirmPassword))
            {
                Console.WriteLine($"Please, confirm your password");
                confirmPassword = Console.ReadLine();
            }

            var formData = new Register { 
                FirstName = firstName, 
                LastName = lastName,
                Email = email,
                Birthday = DateTime.Parse(birthday),
                Password = password,
                ConfirmPassword = confirmPassword,
                Gender = selectedGender
            };

            AccountService.Register(formData);
        }

        public static Gender GenderSelection(string gender)
        {            
            switch (gender)
            {
                case "1":
                    return Gender.Male;       
                case "2":
                    return Gender.Female;
                case "3":
                    return Gender.PreferNotToSay;
                default:
                    return Gender.SelectGender;
            }
        }

        private static string PromptUser(string fieldName)
        {
            Console.WriteLine($"Please, enter a valid {fieldName}");
            return Console.ReadLine().Trim();
        }
    }
}