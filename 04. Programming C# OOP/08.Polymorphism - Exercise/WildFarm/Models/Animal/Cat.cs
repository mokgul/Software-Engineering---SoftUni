
using System;
using WildFarm.Exceptions;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animal
{
    public class Cat : Feline
    {
        private const double WeightGain = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound() => "Meow";
        public override string Feed(IFood food)
        {
            string result = string.Empty;
            result =
                food.GetType().Name switch
                {
                    "Vegetable" => ProduceSound(),
                    "Meat" => ProduceSound(),
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
