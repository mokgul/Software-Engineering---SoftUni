using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            int guests = 0;
            int income = 0;

            string input = Console.ReadLine();
            while (input != "Movie time!")
            {
                guests = int.Parse(input);
                capacity -= guests;
                if (capacity < 0) break;
                income += (guests * 5);
                if (guests % 3 == 0) income -= 5;
                input = Console.ReadLine();
            }
            if (input == "Movie time!")
                Console.WriteLine($"There are {capacity} seats left in the cinema.");
            else if (capacity < 0)
                Console.WriteLine($"The cinema is full.");
            Console.WriteLine($"Cinema income - {income} lv.");
        }
    }
}
