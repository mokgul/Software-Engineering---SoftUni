using System;
using System.Linq;

namespace _03._Treasure_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] key = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string message = Console.ReadLine();
            while (message != "find")
            {
                string decrypted = GetHiddenMessage(message, key);
                Console.WriteLine(TreasureInfo(decrypted));
                message = Console.ReadLine();
            }
            
        }

        private static string GetHiddenMessage(string message, int[] key)
        {
            string result = String.Empty;
            int index = 0;

            foreach (var t in message)
            {
                char current = t;
                current -= (char)key[index];
                index++;
                if(index > key.Length - 1)
                    index = 0;
                result += current;
            }
            return result;
        }

        private static string TreasureInfo(string decrypted)
        {
            int start = decrypted.IndexOf('&');
            int end = decrypted.LastIndexOf('&');
            string resource = decrypted.Substring(start + 1, end - start - 1);

            int startCo = decrypted.IndexOf('<');
            int endCo = decrypted.IndexOf('>');
            string coordinates = decrypted.Substring(startCo + 1, endCo - startCo - 1);

            return $"Found {resource} at {coordinates}";
        }
    }
}
