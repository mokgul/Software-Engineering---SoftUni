using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Snowwhite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //90/100 :(
            List<Dwarf> dwarves = new List<Dwarf>();
            string line = Console.ReadLine();
            while (line != "Once upon a time")
            {
                string[] tokens = line.Split(" <:> ");
                string name = tokens[0];
                string hat = tokens[1];
                int power = int.Parse(tokens[2]);

                if (dwarves.Any(x => x.Name == name && x.HatColor == hat))
                {
                    Dwarf dwarfFromList = dwarves.FirstOrDefault(x => x.Name == name && x.HatColor == hat);
                    int indexOfDwarf = dwarves.IndexOf(dwarfFromList);
                    if (dwarves[indexOfDwarf].Physics < power)
                    {
                        dwarves[indexOfDwarf].Physics = power;
                    }
                }

                else
                {
                    Dwarf dwarf = new Dwarf(name, hat, power);
                    dwarves.Add(dwarf);
                }

                line = Console.ReadLine();
            }
            Dictionary<string, int> hatColors = new Dictionary<string, int>();

            foreach (var dwarf in dwarves)
            {
                if (!hatColors.ContainsKey(dwarf.HatColor))
                {
                    hatColors[dwarf.HatColor] = 0;
                }

                hatColors[dwarf.HatColor]++;
            }
            foreach (var dwarf in dwarves.OrderByDescending(x => x.Physics).ThenByDescending(x => hatColors[x.HatColor]))
            {
                Console.WriteLine($"({dwarf.HatColor}) {dwarf.Name} <-> {dwarf.Physics}");
            }
        }
    }

    class Dwarf
    {
        public Dwarf(string name, string hatColor, int physics)
        {
            this.Name = name;
            this.HatColor = hatColor;
            this.Physics = physics;
        }

        public string Name { get; set; }

        public string HatColor { get; set; }

        public int Physics { get; set; }
    }
}
