using System;

namespace Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string normal = Console.ReadLine();
            string reversed = "";
            int j = 0;

            for(int i = normal.Length - 1; i >= 0; i--)
            {
                reversed += normal[i];
            }
            Console.WriteLine(reversed);
        }
    }
}