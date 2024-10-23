using System;

namespace Greeting_by_name
{
    class GreetingByName
    {
        static void Main(string[] args)
        {
            string firstname = Console.ReadLine();
            string lastname  = Console.ReadLine();
            int age          = int.Parse(Console.ReadLine());
            string town      = Console.ReadLine();
            Console.WriteLine($"You are {firstname} {lastname}, a {age}-years old person from {town}.");
            
        }
    }
}
