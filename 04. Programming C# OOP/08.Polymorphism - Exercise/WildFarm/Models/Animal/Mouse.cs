
using System;
using WildFarm.Exceptions;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animal
{
    public class Mouse : Mammal
    {
        private const double WeightGain = 0.10;
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override string ProduceSound() => "Squeak";
        public override string Feed(IFood food)
        {
            string result = string.Empty;
            result =
                food.GetType().Name switch
                {
                    "Vegetable" => ProduceSound(),
                    "Fruit" => ProduceSound(),
                };
            if (result == string.Empty)
                return result =
                    $"{ProduceSound()}" +
                    Environment.NewLine +
                    $"{this.GetType().Name} does not eat {food.GetType().Name}!";

            this.Weight += (WeightGain * food.Quantity);
            this.FoodEaten += food.Quantity;
            return result;
        }
    }
}
