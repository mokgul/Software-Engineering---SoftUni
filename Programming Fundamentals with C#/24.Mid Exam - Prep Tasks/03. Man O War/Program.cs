using System;
using System.Collections.Generic;
using System.Linq;


namespace _03._Man_O_War
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 90/100 MAYBE RE WRITE ?
            var pirateShip= Console.ReadLine().Split('>')
                .Select(int.Parse).ToList();
            var warShip = Console.ReadLine().Split('>')
                .Select(int.Parse).ToList();
            string result = string.Empty;
            
            int maxHealth = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            while (input != "Retire")
            {
                string[] command = input.Split();
                switch (command[0])
                {
                    case "Fire":
                        int indexFire = int.Parse(command[1]);
                        int damageFire = int.Parse(command[2]);
                        if (IsIndexValid(indexFire, warShip) && damageFire > 0)
                        {
                            warShip[indexFire] -= damageFire;
                            if (warShip[indexFire] <= 0)
                            {
                                result = "won";
                                break;
                            }
                        }
                        break;
                    case "Defend":
                        int startIndex = int.Parse(command[1]);
                        int endIndex = int.Parse(command[2]);
                        int damage = int.Parse(command[3]);
                        if (IsIndexValid(startIndex, pirateShip) && IsIndexValid(endIndex,pirateShip))
                        {
                            for (int i = Math.Min(startIndex, endIndex); i <= Math.Max(startIndex, endIndex); i++)
                            {
                                pirateShip[i] -= damage;
                                if (pirateShip[i] <= 0)
                                {
                                    result = "lost";
                                    break;
                                }
                            }
                        }  
                        break;
                    case "Repair":
                        int index = int.Parse(command[1]);
                        int health = int.Parse(command[2]);
                        if(IsIndexValid(index,pirateShip) && health > 0) 
                            pirateShip[index] = pirateShip[index] + health > maxHealth ? maxHealth : pirateShip[index] += health;
                        break;
                    case "Status":
                        Console.WriteLine(pirateShip.Count(x => x < 0.20 * maxHealth) + $" sections need repair.");
                        break;
                }

                if (result == "won" || result == "lost") break;
                input = Console.ReadLine();
            }
            if (result != "won" && result != "lost")
            {
                Console.WriteLine($"Pirate ship status: {pirateShip.Sum()}");
                Console.WriteLine($"Warship status: {warShip.Sum()}");
            }
            else
            {
                Console.WriteLine(result == "won"
                    ? $"You won! The enemy ship has sunken."
                    : $"You lost! The pirate ship has sunken.");
            }
        }

        private static bool IsIndexValid(int index, List<int> ship) =>
            (index >= 0 && index < ship.Count) ? true : false;
    }
}
