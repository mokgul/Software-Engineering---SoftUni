
namespace WildFarm.Models.Animal
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight,double wingSize)
            : base(name, weight)
        {
            WingSize = wingSize;
        }
        public double WingSize { get; private set; }

        public override string ToString()
            => $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
    }
}
