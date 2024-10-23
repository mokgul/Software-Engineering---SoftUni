
using WildFarm.Exceptions;

namespace WildFarm.AnimalFactories
{
    using Interfaces;
    using Models.Animal;
    using Models.Interfaces;

    public class AnimalFactory : IAnimalFactory
    {
        public AnimalFactory()
        {

        }
        public IAnimal CreateAnimal(string[] args)
        {
            string type = args[0];
            IAnimal animal =
                type switch
                {
                    "Owl" => new Owl(args[1], double.Parse(args[2]), double.Parse(args[3])),
                    "Hen" => new Hen(args[1], double.Parse(args[2]), double.Parse(args[3])),
                    "Mouse" => new Mouse(args[1], double.Parse(args[2]), args[3]),
                    "Dog" => new Dog(args[1], double.Parse(args[2]), args[3]),
                    "Cat" => new Cat(args[1], double.Parse(args[2]), args[3], args[4]),
                    "Tiger" => new Tiger(args[1], double.Parse(args[2]), args[3], args[4]),
                    _ => throw new InvalidTypeOfAnimalException()
                };
            return animal;
        }
    }
}
