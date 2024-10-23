using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double DEFAULT_RACE_MOTORCYCLE_FUEL_CONSUMPTION = 8;
        
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption => DEFAULT_RACE_MOTORCYCLE_FUEL_CONSUMPTION;
    }
}
