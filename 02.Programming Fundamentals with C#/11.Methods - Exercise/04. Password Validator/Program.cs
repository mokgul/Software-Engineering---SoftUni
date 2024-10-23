using System;

namespace _04._Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();


            bool checkOne = (CheckFirst(password)) ? true : false;
            bool checkTwo = (CheckSecond(password)) ? true : false;
            bool checkThree = (CheckThird(password)) ? true : false;

            if (checkOne && checkTwo && checkThree)
                Console.WriteLine("Password is valid");

        }

        private static bool CheckFirst(string password)
        {
            if (password.Length >= 6 && password.Length <= 10)
                return true;

            Console.WriteLine("Password must be between 6 and 10 characters");

            return false;
        }

        private static bool CheckSecond(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {

                if (!char.IsDigit(password[i]) && !char.IsLetter(password[i]))
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                    return false;
                }
            }

            return true;
        }

        private static bool CheckThird(string password)
        {
            int counter = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i]))
                {
                    counter++;
                }
            }

            if (counter < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
                return false;
            }

            return true;
        }
    }
}