using System;

namespace Food_for_Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            int dog = 0;
            int cat = 0;
            double biscuits = 0;
            double eatenByCat = 0;
            double eatenByDog = 0;
            double totalEaten = 0;

            int days = int.Parse(Console.ReadLine());
            double totalFood = double.Parse(Console.ReadLine());

            for (int i = 1; i <= days; i++)
            {
                dog = int.Parse(Console.ReadLine());
                cat = int.Parse(Console.ReadLine());
                if (i % 3 == 0)
                {
                    biscuits += (dog + cat) * 0.10;
                }
                eatenByCat += cat;
                eatenByDog += dog;
            }
            totalEaten = eatenByCat + eatenByDog;
            eatenByDog = (eatenByDog / totalEaten) * 100;
            eatenByCat = (eatenByCat / totalEaten) * 100;
            totalEaten = (totalEaten / totalFood) * 100;

            Console.WriteLine($"Total eaten biscuits: {Math.Round(biscuits)}gr.");
            Console.WriteLine($"{totalEaten:f2}% of the food has been eaten.");
            Console.WriteLine($"{eatenByDog:f2}% eaten from the dog.");
            Console.WriteLine($"{eatenByCat:f2}% eaten from the cat.");
        }
    }
}
