

namespace WildFarm.Models.Animal
{
    using System;

    using Exceptions;
    using Interfaces;
    public class Owl : Bird
    {
        private const double WeightGain = 0.25;
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound() => "Hoot Hoot";
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
