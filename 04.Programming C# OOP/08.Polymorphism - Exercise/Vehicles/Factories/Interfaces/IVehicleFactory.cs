﻿
namespace Vehicles.Factories.Interfaces
{
    using Models.Interfaces;

    public interface IVehicleFactory
    {
        IVehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption);
    }
}
