﻿using System;

namespace _2._1._Simple_Calculations___Concatenate_Data
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string town = Console.ReadLine();

            Console.WriteLine("You are {0} {1}, a {2}-years old person from {3}."
                ,firstName,lastName,age,town);
        }
    }
}
