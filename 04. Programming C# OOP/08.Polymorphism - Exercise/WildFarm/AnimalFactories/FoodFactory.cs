
namespace WildFarm.AnimalFactories
{
    using Interfaces;
    using Models.Food;
    using Models.Interfaces;
    public class FoodFactory : IFoodFactory
    {
        public IFood CreateFood(string type, int quantity)
        {
            IFood food =
                type switch
                {
                    "Vegetable" => new Vegetable(quantity),
                    "Fruit" => new Fruit(quantity),
                    "Meat" => new Meat(quantity),
                    "Seeds" => new Seeds(quantity)
                };
            return food;
        }
    }
}
