using System;

namespace _01._String_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string line = Console.ReadLine();
            while (line != "End")
            {
                string[] commands = line.Split(' ');
                switch (commands[0])
                {
                    case "Translate":
                        string givenChar = commands[1];
                        string replacement = commands[2];
                        input = input.Replace(givenChar, replacement);
                        Console.WriteLine(input);
                        break;
                    case "Includes":
                        string sub = commands[1];
                        string contains = (input.Contains(sub)) ? "True" : "False";
                        Console.WriteLine(contains);
                        break;
                    case "Start":
                        string subToStart = commands[1];
                        string startsWith = (input.StartsWith(subToStart)) ? "True" : "False";
                        Console.WriteLine(startsWith);
                        break;
                    case "Lowercase":
                        input = input.ToLower();
                        Console.WriteLine(input);
                        break;
                    case "FindIndex":
                        int lastIndex = input.LastIndexOf(commands[1]);
                        Console.WriteLine(lastIndex);
                        break;
                    case "Remove":
                        int startIndex = int.Parse(commands[1]);
                        int length = int.Parse(commands[2]);
                        input = input.Remove(startIndex, length);
                        Console.WriteLine(input);
                        break;
                }
                line = Console.ReadLine();
            }
        }
    }
}
