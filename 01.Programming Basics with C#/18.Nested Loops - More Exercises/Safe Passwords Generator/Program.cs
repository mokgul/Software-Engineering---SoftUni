using System;

namespace Safe_Passwords_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            int As = 35;
            int Bs = 64;
            int passwords = 0;
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int maxQtyPasswords = int.Parse(Console.ReadLine());

            for (int x = 1; x <= a; x++)
            {
                for (int y = 1; y <= b; y++)
                {
                    char A = Convert.ToChar(As);
                    char B = Convert.ToChar(Bs);
                    Console.Write($"{A}{B}{x}{y}{B}{A}|");
                    passwords++;
                    As++;
                    if (As > 55) As = 35;
                    Bs++;
                    if (Bs > 96) Bs = 64;
                    if (passwords >= maxQtyPasswords) return;
                }
            }
        }
    }
}
