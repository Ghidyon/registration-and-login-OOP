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
            
            // if blank space or user inputs more than one name, re-prompt user to input field
            while (string.IsNullOrWhiteSpace(firstName) || firstName.Split().Length > 1)
	        {
                firstName = RePromptUser("first name");
	        }	        

            Console.WriteLine("Enter Lastname");
            var lastName = Console.ReadLine().Trim();

            // if blank space or user inputs more than one last name, re-prompt user to input field
            while (string.IsNullOrWhiteSpace(lastName) || lastName.Split().Length > 1)
	        {
                lastName = RePromptUser("last name");
	        }

            Console.WriteLine("Enter email");
            var email = Console.ReadLine().Trim();
            
            // if blank space or user inputs more than one entry, re-prompt user to input field
            while (string.IsNullOrWhiteSpace(email) || email.Split().Length > 1)
	        {
                email = RePromptUser("email");
	        }

            Console.WriteLine("Enter birthday");
            var birthday = Console.ReadLine().Trim();

            // if blank space, re-prompt user to input field
            while (string.IsNullOrWhiteSpace(birthday))
	        {
                birthday = RePromptUser("birthday");
	        }

            Console.WriteLine("Select your Gender: \n1. Male \n2. Female \n3. Prefer not to say");
            var gender = Console.ReadLine().Trim();
            
            // if blank space or user input any value outside the options, re-prompt user to input field
            while (string.IsNullOrWhiteSpace(gender) || (gender != "1" && gender != "2" && gender != "3"))
	        {
                Console.WriteLine("Invalid Gender Selection");
                Console.WriteLine("Select your Gender using the number key: \n1. Male \n2. Female \n3. Prefer not to say");
                gender = Console.ReadLine().Trim();
	        }

            var selectedGender = GenderSelection(gender);
            Console.WriteLine("Enter Password");
            var password = Console.ReadLine();

            Console.WriteLine("Confirm Password");
            var confirmPassword = Console.ReadLine();

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

        private static string RePromptUser(string fieldName)
        {
            Console.WriteLine($"Please, enter a valid {fieldName}");
            return Console.ReadLine().Trim();
        }
    }
}
