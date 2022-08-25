using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Treasure_Hunt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> chest = Console.ReadLine().Split('|').ToList();

            string input = Console.ReadLine();
            while (input != "Yohoho!")
            {
                string[] command = input.Split();
                switch (command[0])
                {
                    case "Loot":
                        Loot(command,chest);
                        break;
                    case "Drop":
                        Drop(command,chest);
                        break;
                    case "Steal":
                        Steal(command,chest);
                        break;
                }
                input = Console.ReadLine();
            }
            double average = chest.Count > 0
                 ? chest.Sum(x => x.Length) / (double)chest.Count()
                 : 0;
            Console.WriteLine(chest.Count > 0
                ? $"Average treasure gain: {average:f2} pirate credits."
                : $"Failed treasure hunt.");
        }

        private static void Steal(string[] command, List<string> chest)
        {
            int count = int.Parse(command[1]);
            List<string> temp = new List<string>();
            count = count > chest.Count ? chest.Count : count;
            while (count > 0)
            {
                temp.Insert(0,chest[^1]);
                chest.RemoveAt(chest.Count - 1);
                count--;
            }
            Console.WriteLine(string.Join(", ", temp));
        }

        private static void Drop(string[] command, List<string> chest)
        {
            int index = int.Parse(command[1]);
            bool validIndex = index >= 0 && index < chest.Count;

            if (validIndex)
            {
                string lootToRemove = chest[index];
                chest.RemoveAt(index);
                chest.Add(lootToRemove);
            }
            
        }

        private static void Loot(string[] command, List<string> chest)
        {
            for (int i = 1; i < command.Length; i++)
            {
                if(chest.Contains(command[i]))
                    continue;
                chest.Insert(0,command[i]);
            }
        }
    }
}
