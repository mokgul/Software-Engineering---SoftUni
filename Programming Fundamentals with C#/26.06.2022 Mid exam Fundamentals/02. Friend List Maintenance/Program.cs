using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Friend_List_Maintenance
{
    internal class Program
    {
        private static int blacklisted = 0;

        private static int Lost = 0;

        static void Main(string[] args)
        {
            List<string> friends = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();


            friends = Commands(friends);
            Print(friends, blacklisted, Lost);
        }

        private static void Print(List<string> friends, int blacklisted, int lost)
        {
            Console.WriteLine($"Blacklisted names: {blacklisted}");
            Console.WriteLine($"Lost names: {lost}");

            Console.WriteLine(string.Join(" ", friends));
        }
        private static List<string> Commands(List<string> friends)
        {
            string input = Console.ReadLine();

            while (input != "Report")
            {
                string[] command = input.Split();
                switch (command[0])
                {
                    case "Blacklist":
                        friends = BlacklistName(friends, command);
                        break;
                    case "Error":
                        friends = ErrorName(friends, command);
                        break;
                    case "Change":
                        friends = ChangeName(friends, command);
                        break;
                }
                input = Console.ReadLine();
            }
            return friends;
        }

        private static List<string> BlacklistName(List<string> friends, string[] commands)
        {
            string name = commands[1];
            int nameIndex = friends.IndexOf(name);
            if (CheckInList(friends, name))
            {
                blacklisted++;
                friends[nameIndex] = "Blacklisted";
                Console.WriteLine($"{name} was blacklisted.");
            }
            else
            {
                Console.WriteLine($"{name} was not found.");
            }

            return friends;
        }

        private static List<string> ErrorName(List<string> friends, string[] commands)
        {
            int index = int.Parse(commands[1]);
            if (index < 0 || index > friends.Count - 1)
                return friends;
            string name = friends[index];
            string blacklisted = "Blacklisted";
            string lost = "Lost";

            if (!(name == blacklisted) && !(name == lost))
            {
                friends[index] = lost;
                Lost++;
                Console.WriteLine($"{name} was lost due to an error.");
            }

            return friends;
        }

        private static List<string> ChangeName(List<string> friends, string[] commands)
        {
            int index = int.Parse(commands[1]);
            if (index < 0 || index > friends.Count - 1)
                return friends;
            string currentName = friends[index];
            string newName = commands[2];

            friends[index] = newName;
            Console.WriteLine($"{currentName} changed his username to {newName}.");

            return friends;
        }

        private static bool CheckInList(List<string> friends, string name)
        {
            if (friends.Contains(name))
                return true;
            return false;
        }
    }
}
