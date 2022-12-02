
using System;
using WildFarm.Exceptions;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animal
{
    public class Dog : Mammal
    {
        private const double WeightGain = 0.40;
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override string ProduceSound() => "Woof!";
        public override string Feed(IFood food)
        {
            if (food.GetType().Name != "Meat")
                throw new ArgumentException(string.Format
                    (FoodTypeNotEatenException.DEFAULT_MESSAGE, this.GetType().Name, food.GetType().Name));

            this.Weight += (WeightGain * food.Quantity);
            this.FoodEaten += food.Quantity;
            return ProduceSound();
        }
    }
}
