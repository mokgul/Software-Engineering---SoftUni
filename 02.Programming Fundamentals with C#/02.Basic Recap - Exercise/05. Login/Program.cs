using System;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string user = Console.ReadLine();
            string password = "";
            string guess    = "";
            int tries = 0;
            for (int i = user.Length - 1; i >= 0; i--)
            {
                string current_letter = user[i].ToString();
                password += current_letter;
            }
            
            while(password != guess)
            {
                if (tries == 3) break;

                guess = Console.ReadLine();
                if(guess != password)
                {
                    Console.WriteLine("Incorrect password. Try again.");
                    tries++;
                }
            }
            if (tries == 3)
                Console.WriteLine($"User {user} blocked!");
            else
                Console.WriteLine($"User {user} logged in.");
        }
    }
}