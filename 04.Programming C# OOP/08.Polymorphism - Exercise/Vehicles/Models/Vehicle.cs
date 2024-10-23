
namespace Vehicles.Models
{
    using Exceptions;
    using Interfaces;

    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity,
            double fuelConsumption, double consumptionIncrease)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption + consumptionIncrease;
        }
        
        public double FuelQuantity { get; private set; }
        public double FuelConsumption { get; private set; }

        public string Drive(double distance)
        {
            if (FuelQuantity - distance * FuelConsumption < 0)
                throw new InsufficientFuelException(string.Format(
                    ExceptionMessages.InsufficientFuelExceptionMessage,
                   this.GetType().Name));

            FuelQuantity -= distance * FuelConsumption;
            return $"{this.GetType().Name} travelled {distance} km";
        }
        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }

        public override string ToString()
            => $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}
