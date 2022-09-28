using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _05._Nether_Realms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Demon> demons = new List<Demon>();
            string[] input = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string healthPattern = @"(?<health>[^\d\+\-*/.])";

            for (int i = 0; i < input.Length; i++)
            {
                string name = input[i];
                MatchCollection match = Regex.Matches(name, healthPattern);
                int health = 0;
                foreach (Match m in match)
                {
                    char current = char.Parse(m.ToString());
                    health += current;
                }

                double damage = 0;
                string damageSumNumbers = @"\-?(?<damage>[\d]+\.?[\d]*)";
                MatchCollection sumNumbers = Regex.Matches(name, damageSumNumbers);
                foreach (Match m in sumNumbers)
                {
                    damage += double.Parse(m.ToString());
                }

                int starCount = name.ToCharArray().Count(x => x == '*');
                damage = damage * Math.Pow(2, starCount);
                int dashCount = name.ToCharArray().Count(x => x == '/');
                damage = damage / Math.Pow(2, dashCount);
                //foreach(char ch in name)
                //    if (ch == '*')
                //        damage *= 2;
                //foreach (char ch in name)
                //    if (ch == '/')
                //        damage /= 2;
                demons.Add(new Demon(name,health,damage));
            }
            demons = demons.OrderBy(x => x.Name).ToList();
            demons.ForEach(x => Console.WriteLine($"{x.Name} - {x.Health} health, {x.Damage:f2} damage"));
        }
    }

    class Demon
    {
        public Demon(string name, int health, double damage)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
        }
        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }
    }
}
