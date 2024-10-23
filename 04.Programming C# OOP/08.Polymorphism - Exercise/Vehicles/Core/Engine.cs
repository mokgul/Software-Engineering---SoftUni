
using Vehicles.Factories;

namespace Vehicles.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Exceptions;
    using Factories.Interfaces;
    using Interfaces;
    using IO.Interfaces;
    using Models.Interfaces;

    public class Engine : IEngine
    {
        private readonly IReader _reader;
        private readonly IWriter _writer;

        private readonly IVehicleFactory _factory;

        private readonly ICollection<IVehicle> _vehicles;

        private Engine()
        {
            _vehicles = new HashSet<IVehicle>();
            _factory = new VehicleFactory();
        }

        public Engine(IReader reader, IWriter writer) : this()
        {
            _reader = reader;
            _writer = writer;
        }
        public void Run()
        {
            _vehicles.Add(CreateVehicleFactory());
            _vehicles.Add(CreateVehicleFactory());

            int n = int.Parse(_reader.ReadLine());
            for (int i = 0; i < n; i++)
            {
                try
                {
                    ReceiveCommands();
                }
                catch (InsufficientFuelException ife)
                {
                    _writer.WriteLine(ife.Message);
                }
                catch (InvalidVehicleTypeException ivte)
                {
                    _writer.WriteLine(ivte.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            PrintAllVehicles();
        }

        private IVehicle CreateVehicleFactory()
        {
            string[] input = _reader.ReadLine().Split();
            string type = input[0];
            double quantity = double.Parse(input[1]);
            double consumption = double.Parse(input[2]);
            IVehicle vehicle = _factory.CreateVehicle(type, quantity, consumption);

            return vehicle;
        }

        private void ReceiveCommands()
        {
            string[] commands = _reader.ReadLine().Split();
            string commnad = commands[0];
            string type = commands[1];
            double arg = double.Parse(commands[2]);

            IVehicle vehicle = _vehicles.FirstOrDefault(v => v.GetType().Name == type);
            if (vehicle == null) throw new InvalidVehicleTypeException();
            if (commnad == "Drive") _writer.WriteLine(vehicle.Drive(arg));
            else if (commnad == "Refuel") vehicle.Refuel(arg);
        }

        private void PrintAllVehicles()
        {
            foreach (IVehicle vehicle in _vehicles)
            {
                _writer.WriteLine(vehicle.ToString());
            }
        }
    }
}
