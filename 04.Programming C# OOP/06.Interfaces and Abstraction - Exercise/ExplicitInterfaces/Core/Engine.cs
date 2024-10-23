

namespace ExplicitInterfaces.Core
{
    using IO.Interfaces;
    using Interfaces;
    using Models;
    using ExplicitInterfaces.Models.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;

        private IResident _resident;
        private IPerson _person;
        private Citizen _citizen;
        public Engine(IReader reader, IWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }
        public void Run()
        {
            ReceiveInformation();
        }

        private void ReceiveInformation()
        {
            string line = _reader.ReadLine();
            while (line != "End")
            {
                string[] args = line.Split(' ');
                string name = args[0];
                string country = args[1];
                int age = int.Parse(args[2]);
                _citizen = new Citizen(name, country, age);
                _resident = _citizen;
                _person = _citizen;
                _writer.WriteLine(_person.GetName());
                _writer.WriteLine(_resident.GetName());
                line = _reader.ReadLine();
            }
        }
    }
}
