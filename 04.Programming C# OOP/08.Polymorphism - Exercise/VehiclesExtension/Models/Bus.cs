
namespace VehiclesExtension.Models
{
    using Exceptions;
    public class Bus : Vehicle
    {
        private const double consumptionIncrease = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, consumptionIncrease, tankCapacity)
        {
        }

        public string DriveEmpty(double distance)
        {
            double fuelNeeded = distance * (FuelConsumption - consumptionIncrease);
            if (FuelQuantity - fuelNeeded < 0)
                throw new InsufficientFuelException(string.Format(
                    ExceptionMessages.InsufficientFuelExceptionMessage,
                    this.GetType().Name));

            FuelQuantity -= fuelNeeded;
            return $"{this.GetType().Name} travelled {distance} km";
        }
    }
}
