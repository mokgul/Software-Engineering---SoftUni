using System;

namespace Password_Guess
{
    class PasswordGuess
    {
        static void Main(string[] args)
        {
            string password = "s3cr3t!P@ssw0rd";
            string guess = Console.ReadLine();
            if (guess == password)
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }
        }
    }
}
