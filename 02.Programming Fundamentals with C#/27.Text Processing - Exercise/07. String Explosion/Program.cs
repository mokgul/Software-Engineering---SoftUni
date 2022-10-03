using System;

namespace _07._String_Explosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int strength = 0;
            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];
                if (current == '>')
                {
                    int index = i + 1;
                    if (input[index] == '>') continue;
                    if (char.IsDigit(input[index]))
                    {
                        strength += int.Parse(input[index].ToString());
                    }
                    while (true)
                    {
                        input = input.Remove(index, 1);
                        strength--;

                        if (strength == 0)
                            break;
                        if (index > input.Length - 1) break;
                        if (input[index] == '>') break;
                    }
                }
            }

            Console.WriteLine(input);
        }
    }
}
