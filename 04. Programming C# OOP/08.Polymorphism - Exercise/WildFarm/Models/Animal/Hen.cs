
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animal
{
    public class Hen : Bird
    {
        private const double WeightGain = 0.35;
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound() => "Cluck";

        public override string Feed(IFood food)
        {
            this.Weight += (WeightGain * food.Quantity);
            this.FoodEaten += food.Quantity;
            return ProduceSound();
        }
    }
}
