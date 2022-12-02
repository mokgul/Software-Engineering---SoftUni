
namespace WildFarm.Models.Animal
{
    using System;

    using Exceptions;
    using Interfaces;
    public class Tiger : Feline
    {
        private const double WeightGain = 1.00;
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound() => "ROAR!!!";
        public override string Feed(IFood food)
        {
            if (food.GetType().Name != "Meat")
                return $"{ProduceSound()}" +
                    Environment.NewLine +
                    $"{this.GetType().Name} does not eat {food.GetType().Name}!";

            this.Weight += (WeightGain * food.Quantity);
            this.FoodEaten += food.Quantity;
            return ProduceSound();
        }
    }
}
