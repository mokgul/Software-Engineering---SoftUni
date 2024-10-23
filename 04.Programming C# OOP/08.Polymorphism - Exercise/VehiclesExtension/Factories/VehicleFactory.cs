
namespace VehiclesExtension.Factories
{
    using Exceptions;
    using Interfaces;
    using Models;
    using Models.Interfaces;
    public class VehicleFactory : IVehicleFactory
    {
        public VehicleFactory()
        {

        }
        public IVehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption,double tankCapacity)
        {
            IVehicle vehicle =
                (type == "Car") ? new Car(fuelQuantity, fuelConsumption,tankCapacity)
                : (type == "Truck") ? new Truck(fuelQuantity, fuelConsumption,tankCapacity)
                    : (type == "Bus") ? new Bus(fuelQuantity, fuelConsumption, tankCapacity)
                : throw new InvalidVehicleTypeException();
            return vehicle;
        }
    }
}
