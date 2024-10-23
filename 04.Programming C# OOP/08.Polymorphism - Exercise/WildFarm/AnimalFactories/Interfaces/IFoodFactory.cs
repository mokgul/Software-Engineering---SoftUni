
namespace WildFarm.AnimalFactories.Interfaces
{
    using Models.Interfaces;
    public interface IFoodFactory
    {
        IFood CreateFood(string type, int quantity);
    }
}
