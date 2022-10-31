using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double DEFAULT_CAR_FUEL_CONSUMPTION = 3;
        
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption => DEFAULT_CAR_FUEL_CONSUMPTION;

    }
}
