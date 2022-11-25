
namespace FoodShortage.Core
{
    using System.Collections.Generic;

    using Models;
    using Interfaces;
    using IO.Interfaces;
    using Models.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;

        private readonly ICollection<IIdentifiable> _buyerList;

        private int _foodBought = 0;

        private Engine()
        {
            _buyerList = new List<IIdentifiable>();
        }
        public Engine(IReader reader, IWriter writer) : this()
        {
            _reader = reader;
            _writer = writer;
        }
        public void Run()
        {
            ReceivePeople();
            ReceiveNames();
            _writer.WriteLine(_foodBought.ToString());
        }

        private void ReceiveNames()
        {
            string line = _reader.ReadLine();
            while (line != "End")
            {
                foreach (var person in _buyerList)
                {
                    if (person.Name == line)
                    {
                        IBuyer current = (IBuyer)person;
                        current.BuyFood();
                    }
                }
                line = _reader.ReadLine();
            }
            foreach (var person in _buyerList)
            {
                IBuyer current = (IBuyer)person;
                _foodBought += current.Food;
            }
        }

        private void ReceivePeople()
        {
            int qty = int.Parse(_reader.ReadLine());
            for (int i = 1; i <= qty; i++)
            {
                string[] person = _reader.ReadLine().Split();
                _buyerList.Add(person.Length == 4
                    ? new Citizen(person[0], int.Parse(person[1]), person[2], person[3])
                    : new Rebel(person[0], int.Parse(person[1]), person[2]));
            }
        }
    }
}
