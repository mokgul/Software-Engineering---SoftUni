using System;
using System.Collections.Generic;

namespace _03._Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();
            string[] input = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in input)
            {
                string[] tokens = item.Split(' ');
                try
                {
                    Card card = new Card(tokens[0], tokens[1]);
                    cards.Add(card);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(string.Join(" ", cards));
        }
    }
}
