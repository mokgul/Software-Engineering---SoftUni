
namespace WildFarm.AnimalFactories.Interfaces
{
    using Models.Interfaces;
    public interface IAnimalFactory
    {
        IAnimal CreateAnimal(string[] args);
    }
}
