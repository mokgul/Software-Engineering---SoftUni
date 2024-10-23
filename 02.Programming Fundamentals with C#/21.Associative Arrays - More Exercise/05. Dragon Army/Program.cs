using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Dragon_Army
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dragons = new Dictionary<string, List<Dragon>>();
            int dragonsQty = int.Parse(Console.ReadLine());
            for (int i = 0; i < dragonsQty; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string type = tokens[0];
                string name = tokens[1];
                int damage = tokens[2] == "null" ? 45 : int.Parse(tokens[2]);
                int health = tokens[3] == "null" ? 250 : int.Parse(tokens[3]);
                int armor = tokens[4] == "null" ? 10 : int.Parse(tokens[4]);

                if (dragons.ContainsKey(type) && dragons[type].Any(d => d.Name == name))
                {
                    Dragon currentDragon = dragons[type].First(i => i.Name == name);
                    currentDragon.Damage = damage;
                    currentDragon.Health = health;
                    currentDragon.Armor = armor;
                    continue;
                }

                Dragon dragon = new Dragon(name, damage, health, armor);
                if(!dragons.ContainsKey(type))
                {
                    dragons.Add(type, new List<Dragon>());
                }
                dragons[type].Add(dragon);
            }

            foreach (var item in dragons)
            {
                Console.WriteLine($"{item.Key}::({item.Value.Average(x => x.Damage):f2}/" +
                                  $"{item.Value.Average(x => x.Health):f2}/" +
                                  $"{item.Value.Average(x => x.Armor):f2})");
                foreach (var dragon in item.Value.OrderBy(x => x.Name))
                {
                    Console.WriteLine($"-{dragon.Name} -> damage: {dragon.Damage}, health: {dragon.Health}, armor: {dragon.Armor}");
                }
            }
        }
    }

    class Dragon
    {
        public Dragon(string name, int damage, int health, int armor)
        {
            this.Name = name;
            this.Damage = damage;
            this.Health = health;
            this.Armor = armor;
        }

        public string Name { get; set; }
        public int Damage { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
    }
}
