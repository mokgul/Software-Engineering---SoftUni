
namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double ConsumptionIncrease = 0.9;
        public Car(double fuel, double fuelQuantity,
            double fuelConsumption)
            : base(fuel, fuelQuantity, fuelConsumption, ConsumptionIncrease)
        {
        }
    }
}
