using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Cards_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> playerOne = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            List<int> playerTwo = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            while (playerOne.Count > 0 && playerTwo.Count > 0)
            {
                int i = 0;
                if (playerOne[i] > playerTwo[i])
                {
                    playerOne.Add(playerOne[i]);//adds the winning card
                    playerOne.Add(playerTwo[i]); //adds the losing card

                    playerOne.RemoveAt(i);
                    playerTwo.RemoveAt(i);
                }
                else if (playerOne[i] < playerTwo[i])
                {
                    playerTwo.Add(playerTwo[i]);//adds the winning card
                    playerTwo.Add(playerOne[i]);//adds the losing card

                    playerOne.RemoveAt(i);
                    playerTwo.RemoveAt(i);
                }
                else
                {
                    playerOne.RemoveAt(i);
                    playerTwo.RemoveAt(i);
                }
            }
            string winner = string.Empty;
            if (playerOne.Count > 0)
            {
                winner = "First";
                PrintResult(playerOne, winner);
            }
            else
            {
                winner = "Second";
                PrintResult(playerTwo, winner);
            }
        }

        private static void PrintResult(List<int> winner, string player)
        {
            int sum = 0;
            for (int i = 0; i < winner.Count; i++)
            {
                sum += winner[i];
            }

            Console.WriteLine($"{player} player wins! Sum: {sum}");
        }
    }
}
