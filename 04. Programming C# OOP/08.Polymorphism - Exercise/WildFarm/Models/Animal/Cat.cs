
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
            string foodName = food.GetType().Name; 
            result =
                foodName switch
                {
                    "Vegetable" => ProduceSound(),
                    "Meat" => ProduceSound(),
                    _ => result
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
