using System;
using System.Globalization;

namespace SocialSecurityNumber_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string socialSecurityNumber = FetchSocialSecurityNumber(args);

            string gender = GetGender(socialSecurityNumber);

            int age = CalculateAge(socialSecurityNumber);

            Console.WriteLine($"This is a: {gender}, with age: {age}");
        }

        private static string FetchSocialSecurityNumber(string[] args)
        {
            string socialSecurityNumber;

            // Input
            if (args.Length > 0)
            {
                // if input from terminal is already done
                Console.WriteLine($"You provided: {args[0]}");
                socialSecurityNumber = args[0];
            }
            else

            {   // Ask for input
                Console.WriteLine("Please input your Social security number YYMMDD-XXXX");
                socialSecurityNumber = Console.ReadLine();
            }

            return socialSecurityNumber;
        }

        private static int CalculateAge(string socialSecurityNumber)
        {
            string birthDateString = socialSecurityNumber.Substring(0, 6);

            DateTime birthDate = DateTime.ParseExact(birthDateString, "yyMMdd", CultureInfo.InvariantCulture);

            int age = DateTime.Now.Year - birthDate.Year;

            if (birthDate.Month > DateTime.Today.Month || birthDate.Month == DateTime.Now.Month && birthDate.Day > DateTime.Now.Day)
            {
                age = age - 1;
            }

            return age;
        }

        private static string GetGender(string socialSecurityNumber)
        {
            string genderNumberString = socialSecurityNumber.Substring(socialSecurityNumber.Length - 2, 1);

            int genderNumber = int.Parse(genderNumberString);

            string gender;

            if (genderNumber % 2 == 0) // True/false  (Boolean)
            {
                gender = "Female";
            }
            else
            {
                gender = "Male";
            }

            return gender;
        }
    }
}
