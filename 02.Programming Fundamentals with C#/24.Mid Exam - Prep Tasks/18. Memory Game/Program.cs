using System;
using System.Collections.Generic;
using System.Linq;

namespace _18._Memory_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> pairs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            int moves = 0;
            string line = Console.ReadLine();
            while (line != "end")
            {
                moves++;
                string[] tokens = line.Split();
                int index1 = int.Parse(tokens[1]);
                int index2 = int.Parse(tokens[0]);
                if (!AreValid(index1, index2, pairs))
                {
                    string penalty = "-" + moves.ToString() + "a";
                    int midIndex1 = pairs.Count / 2;
                    int midIndex2 = pairs.Count / 2 + 1;
                    pairs.Insert(midIndex1, penalty);
                    pairs.Insert(midIndex2, penalty);
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }
                else
                {
                    if (pairs[index1] == pairs[index2])
                    {
                        string temp = pairs[index1];
                        pairs.Remove(temp);
                        pairs.Remove(temp);
                        Console.WriteLine($"Congrats! You have found matching elements - {temp}!");
                    }
                    else if (pairs[index1] != pairs[index2])
                    {
                        Console.WriteLine("Try again!");
                    }
                    if (pairs.Count == 0)
                    {
                        Console.WriteLine($"You have won in {moves} turns!");
                        return;
                    }
                }
                line = Console.ReadLine();
            }

            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(string.Join(" ", pairs));
        }

        private static bool AreValid(int index1, int index2, List<string> pairs)
        {
            if (index1 != index2
                && (index1 >= 0 && index1 < pairs.Count)
                && (index2 >= 0 && index2 < pairs.Count))
                return true;

            return false;
        }
    }
}
