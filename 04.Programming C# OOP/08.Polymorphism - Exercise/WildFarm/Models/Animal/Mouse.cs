
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
            string foodName = food.GetType().Name; 
            result =
                 foodName switch
                {
                    "Vegetable" => ProduceSound(),
                    "Fruit" => ProduceSound(),
                    _ => result,
                };
            if (result == string.Empty)
                throw new ArgumentException(string.Format
                    (FoodTypeNotEatenException.DEFAULT_MESSAGE, this.GetType().Name, food.GetType().Name));

            this.Weight += (WeightGain * food.Quantity);
            this.FoodEaten += food.Quantity;
            return result;
        }
    }
}
