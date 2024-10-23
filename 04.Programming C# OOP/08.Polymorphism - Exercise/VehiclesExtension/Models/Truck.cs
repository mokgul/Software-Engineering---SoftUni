
namespace VehiclesExtension.Models
{
    using Exceptions;
    public class Truck : Vehicle
    {
        private const double ConsumptionIncrease = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, ConsumptionIncrease, tankCapacity)
        {
        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
                throw new InvalidFuelValue(ExceptionMessages.InvalidFuelValueExceptionMessage);
            if (FuelQuantity + liters > TankCapacity)
            {
                throw new UnableToFitFuelException(string.Format(
                    ExceptionMessages.UnableToFitFuelExceptionMessage, liters));
            }
            this.FuelQuantity += liters * 0.95;
        }
    }
}
