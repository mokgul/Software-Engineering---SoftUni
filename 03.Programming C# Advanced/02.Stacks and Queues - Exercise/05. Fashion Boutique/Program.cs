using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    internal class Boutique
    {
        private static Stack<int> clothes;
        private static int capacity;
        private static int racks = 1;
        private static Predicate<Stack<int>> isNotEmpty = c => c.Count > 0;
        static void Main(string[] args)
        {
            Inputs();
            GetNeededRacks();
            PrintRacks();
        }

        private static void PrintRacks() => Console.WriteLine(Boutique.racks);

        private static void GetNeededRacks()
        {
            int sum = 0;
            while (Boutique.isNotEmpty(Boutique.clothes))
            {
                if (sum + Boutique.clothes.Peek() < Boutique.capacity)
                {
                    sum += Boutique.clothes.Pop();
                }
                else if (sum + Boutique.clothes.Peek() == Boutique.capacity)
                {
                    sum += Boutique.clothes.Pop();
                    sum = 0;
                    if (Boutique.isNotEmpty(Boutique.clothes)) Boutique.racks++;
                }
                else if (sum + Boutique.clothes.Peek() > Boutique.capacity)
                {
                    sum = 0;
                    Boutique.racks++;
                }
            }
        }

        private static void Inputs()
        {
            Boutique.clothes = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Boutique.capacity = int.Parse(Console.ReadLine());
        }
    }
}
