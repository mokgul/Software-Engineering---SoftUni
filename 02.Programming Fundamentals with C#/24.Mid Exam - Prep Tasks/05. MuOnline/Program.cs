using System;
using System.Threading;

namespace _05._MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int bitcoins = 0;
            int room = 0;

            string[] rooms = Console.ReadLine().Split('|');

            for (int i = 0; i < rooms.Length; i++)
            {
                string[] tokens = rooms[i].Split();
                string command = tokens[0];
                int number = int.Parse(tokens[1]);

                if (command == "potion")
                {
                    bool overheal = number + health > 100;
                    Console.WriteLine(!overheal
                        ? $"You healed for {number} hp."
                        : $"You healed for {100 - health} hp.");
                    health = overheal ? 100 : number + health;
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (command == "chest")
                {
                    bitcoins += number;
                    Console.WriteLine($"You found {number} bitcoins.");
                }
                else
                {
                    health -= number;
                    Console.WriteLine(health > 0
                        ? $"You slayed {command}."
                        : $"You died! Killed by {command}.");
                }

                room++;
                if (health <= 0)
                {
                    Console.WriteLine($"Best room: {room}");
                    return;
                }
            }

            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
