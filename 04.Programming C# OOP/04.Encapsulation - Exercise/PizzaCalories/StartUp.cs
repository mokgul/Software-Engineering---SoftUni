using System;
using System.Linq;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Pizza pizza = new Pizza(Console.ReadLine().Substring(6));
                string[] doughTokens = Console.ReadLine().Split().ToArray();
                pizza.Dough = new Dough(doughTokens[1], doughTokens[2], int.Parse(doughTokens[3]));
                string input = Console.ReadLine();
                while (input != "END")
                {
                    string[] argms = input.Split();
                    Topping topping = new Topping(argms[1], int.Parse(argms[2]));
                    if(!pizza.TooManyToppings())
                        pizza.AddTopping(topping);
                    input = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories():f2} Calories.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
