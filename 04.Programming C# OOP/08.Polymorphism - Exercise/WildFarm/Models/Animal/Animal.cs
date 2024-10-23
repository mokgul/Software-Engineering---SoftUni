
namespace WildFarm.Models.Animal
{
    using Interfaces;
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }
        public string Name { get; private set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }
        public abstract string ProduceSound();
        public abstract string Feed(IFood food);
    }
}
