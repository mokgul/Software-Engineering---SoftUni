
namespace Vehicles.Factories
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
        public IVehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption)
        {
            IVehicle vehicle =
                (type == "Car") ? new Car(fuelQuantity, fuelConsumption)
                : (type == "Truck") ? new Truck(fuelQuantity, fuelConsumption)
                : throw new InvalidVehicleTypeException();
            return vehicle;
        }
    }
}
