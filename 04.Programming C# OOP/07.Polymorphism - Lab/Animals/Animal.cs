
namespace Animals
{
    public class Animal
    {
        private readonly string _name;
        private readonly string _favouriteFood;

        public Animal(string name, string food)
        {
            Name = name;
            FavouriteFood = food;
        }

        public string Name { get; protected set; }
        public string FavouriteFood { get; protected set; }
        public virtual string ExplainSelf()
            => $"I am {Name} and my favourite food is {FavouriteFood}";
    }
}
