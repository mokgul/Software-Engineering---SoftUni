
namespace BirthdayCelebrations.Core
{
    using System.Collections.Generic;

    using Interfaces;
    using IO.Interfaces;
    using Models;
    using Models.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;

        private readonly ICollection<IBirthdate> _birthdays;

        private Engine()
        {
            _birthdays = new List<IBirthdate>();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            _reader = reader;
            _writer = writer;
        }
        public void Run()
        {
            ReceiveInformation();
            PrintBirthdays();
        }

        private void PrintBirthdays()
        {
            string year = _reader.ReadLine();
            foreach (var birthdate in _birthdays)
            {
                if (birthdate.Birthdate.EndsWith(year))
                    _writer.WriteLine(birthdate.Birthdate);
            }
        }

        private void ReceiveInformation()
        {
            string line = _reader.ReadLine();
            while (line != "End")
            {
                string[] args = line.Split();
                if (args[0] == "Citizen")
                    _birthdays.Add(new Citizen(
                        args[1],
                        int.Parse(args[2]),
                        args[3],
                        args[4]));
                else if (args[0] == "Pet")
                    _birthdays.Add(new Pet(
                        args[1],
                        args[2]));
                line = _reader.ReadLine();
            }
        }
    }
}
