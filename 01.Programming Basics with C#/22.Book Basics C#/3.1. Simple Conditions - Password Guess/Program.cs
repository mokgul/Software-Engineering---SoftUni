using System;

namespace _3._1._Simple_Conditions___Password_Guess
{
    internal class Program
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
