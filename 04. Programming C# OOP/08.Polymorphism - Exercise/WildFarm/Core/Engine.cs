

namespace WildFarm.Core
{
    using System;
    using System.Collections.Generic;

    using AnimalFactories;
    using AnimalFactories.Interfaces;
    using Interfaces;
    using IO.Interfaces;
    using Models.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;

        private readonly IAnimalFactory _animalFactory;
        private readonly IFoodFactory _foodFactory;
        private readonly ICollection<IAnimal> _animals;

        private Engine()
        {
            _animals = new List<IAnimal>();
            _foodFactory = new FoodFactory();
            _animalFactory = new AnimalFactory();
        }
        public Engine(IReader reader, IWriter writer) : this()
        {
            _reader = reader;
            _writer = writer;
        }
        public void Run()
        {
            ReceiveInformation();
            PrintAnimals();
        }

        private void PrintAnimals()
        {
            foreach (var animal in _animals)
            {
                _writer.WriteLine(animal.ToString());
            }
        }

        private void ReceiveInformation()
        {
            while (true)
            {
                string[] animalInfo = _reader.ReadLine().Split();
                if (animalInfo[0] == "End") break;
                IAnimal animal = CreateAnimalFactory(animalInfo);

                string[] foodInfo = _reader.ReadLine().Split();
                IFood food = _foodFactory.CreateFood(foodInfo[0], int.Parse(foodInfo[1]));

                //_writer.WriteLine(animal.ProduceSound());
                _writer.WriteLine(animal.Feed(food));


                _animals.Add(animal);
            }
        }

        private IAnimal CreateAnimalFactory(string[] args)
        {
            IAnimal animal = _animalFactory.CreateAnimal(args);
            return animal;
        }
    }
}
