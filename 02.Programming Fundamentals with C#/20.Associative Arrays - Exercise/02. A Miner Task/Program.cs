using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> info = new Dictionary<string, int>();

            string resourse = string.Empty;
            string quantity = string.Empty;

            while (resourse != "stop")
            {
                resourse = Console.ReadLine();
                if (resourse == "stop") break;

                quantity = Console.ReadLine();

                if (!info.ContainsKey(resourse))
                {
                    info.Add(resourse, 0);
                }

                info[resourse] += int.Parse(quantity);
            }

            foreach (var item in info)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
