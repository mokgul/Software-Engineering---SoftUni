using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Shopping_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> shoppingList = Console.ReadLine().Split('!').ToList();

            string input = Console.ReadLine();
            while (input != "Go Shopping!")
            {
                string[] tokens = input.Split();
                switch (tokens[0])
                {
                    case "Urgent":
                        if (!shoppingList.Contains(tokens[1]))
                            shoppingList.Insert(0, tokens[1]);
                        break;
                    case "Unnecessary":
                        if (shoppingList.Contains(tokens[1]))
                            shoppingList.Remove(tokens[1]);
                        break;
                    case "Correct":
                        if (shoppingList.Contains(tokens[1]))
                        {
                            int index = shoppingList.IndexOf(tokens[1]);
                            shoppingList[index] = tokens[2];
                        }
                        break;
                    case "Rearrange":
                        if (shoppingList.Contains(tokens[1]))
                        {
                            string temp = tokens[1];
                            shoppingList.Remove(tokens[1]);
                            shoppingList.Add(temp);
                        }
                        break;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", shoppingList));
        }
    }
}
