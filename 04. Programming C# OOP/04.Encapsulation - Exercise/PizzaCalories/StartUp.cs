using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split();
            string flourType = tokens[1];
            string bakingTechnique = tokens[2];
            int weight = int.Parse(tokens[3]);
            try
            {
                Dough dough = new Dough(flourType, bakingTechnique, weight);
                Console.WriteLine($"{dough.TotalCalories:f2}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
