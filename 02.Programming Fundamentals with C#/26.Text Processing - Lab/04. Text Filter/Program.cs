using System;

namespace _04._Text_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] banList = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();

            foreach (string ban in banList)
            {
                string textToReplace = new string('*', ban.Length);
                if (text.Contains(ban))
                {
                    text = text.Replace(ban, textToReplace);
                }
            }

            Console.WriteLine(text);
        }
    }
}
