using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private const double DEFAULT_SPORT_CAR_FUEL_CONSUMPTION = 10;
       
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption => DEFAULT_SPORT_CAR_FUEL_CONSUMPTION;
    }
}
