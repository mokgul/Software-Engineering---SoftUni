
namespace CollectionHierarchy.Core
{
    using System;
    using System.Collections.Generic;

    using Interfaces;
    using CollectionHierarchy.IO.Interfaces;
    using Models;
    using CollectionHierarchy.Models.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;

        private IAdd _addCollection;
        private IRemove _removeCollection;
        private IUsed _myList;

        private List<int> resultsFirst;
        private List<string> resultsSecond;
        private List<string> resultsThird;
        private List<string> resultsFourth;
        private List<string> resultsFive;

        private Engine()
        {
            _addCollection = new AddCollection();
            _removeCollection = new AddRemoveCollection();
            _myList = new MyList();

            resultsFirst = new List<int>();
            resultsSecond = new List<string>();
            resultsThird = new List<string>();
            resultsFourth = new List<string>();
            resultsFive = new List<string>();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            _reader = reader;
            _writer = writer;
        }
        public void Run()
        {
            ReceiveItems();
            RemoveItems();
            PrintResults();
        }

        private void PrintResults()
        {
            _writer.WriteLine(string.Join(" ", resultsFirst));
            _writer.WriteLine(string.Join(" ", resultsFourth));
            _writer.WriteLine(string.Join(" ", resultsFive));
            _writer.WriteLine(string.Join(" ", resultsSecond));
            _writer.WriteLine(string.Join(" ", resultsThird));
        }

        private void RemoveItems()
        {
            int itemsToRemove = int.Parse(_reader.ReadLine());
            for (int i = 1; i <= itemsToRemove; i++)
            {
                resultsSecond.Add(_removeCollection.Remove());
                resultsThird.Add(_myList.Remove());
            }
        }

        private void ReceiveItems()
        {
            string[] items = _reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in items)
            {
                resultsFirst.Add(_addCollection.Add(item));
                resultsFourth.Add(_removeCollection.Add(item).ToString());
                resultsFive.Add(_myList.Add(item).ToString());
            }
        }
    }
}
