
namespace VehiclesExtension.Models
{
    using Exceptions;
    using Interfaces;
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        protected Vehicle(double fuelQuantity,
            double fuelConsumption, double consumptionIncrease, double tankCapacity)
        {
            //TankCapacity MUST BE Initialized before FuelQuantity or the validation
            //for fuelQuantity wont work properly (capacity will be 0 )
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption + consumptionIncrease;
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            protected set
            {
                if (value > TankCapacity)
                    fuelQuantity = 0;
                else fuelQuantity = value;
            }
        }
        public double FuelConsumption { get; private set; }
        public double TankCapacity { get; private set; }

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
            if (liters <= 0)
                throw new InvalidFuelValue(ExceptionMessages.InvalidFuelValueExceptionMessage);
            if (FuelQuantity + liters > TankCapacity)
            {
                throw new UnableToFitFuelException(string.Format(
                    ExceptionMessages.UnableToFitFuelExceptionMessage, liters));
            }
            this.FuelQuantity += liters;
        }

        public override string ToString()
            => $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}
