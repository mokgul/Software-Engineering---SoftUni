
namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double ConsumptionIncrease = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption, ConsumptionIncrease)
        {
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters * 0.95);
        }
    }
}
