namespace Vehicles.Models.Interfaces
{
    public interface IVehicle
    {
        double Fuel { get; }
        double FuelQuantity { get; }

        double FuelConsumption { get; }

        string Drive(double distance);
        void Refuel(double fuel);
    }
}