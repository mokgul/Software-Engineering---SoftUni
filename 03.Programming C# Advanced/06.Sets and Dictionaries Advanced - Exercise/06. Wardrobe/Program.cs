using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,Dictionary<string,int>> wardrobe = new Dictionary<string,Dictionary<string,int>>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                if(!wardrobe.ContainsKey(color))
                    wardrobe.Add(color, new Dictionary<string,int>());
                for(int j = 1; j < input.Length; j++)
                { 
                    string clothing = input[j];
                    if(!wardrobe[color].ContainsKey(clothing))
                        wardrobe[color].Add(clothing,0);
                    wardrobe[color][clothing]++;
                }
            }

            string[] findCloth = Console.ReadLine().Split();
            string searchedColor = findCloth[0];
            string searchedItem = findCloth[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var cloth in color.Value)
                {
                    string current = $"* {cloth.Key} - {cloth.Value}";
                    if (color.Key == searchedColor && cloth.Key == searchedItem)
                        current += " (found!)";
                    Console.WriteLine(current);
                }
            }
        }
    }
}
