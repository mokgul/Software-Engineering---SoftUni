﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Facade
{
    public class CarInfoBuilder : CarBuilderFacade
    {
        public CarInfoBuilder(Car car)
        {
            Car = car;
        }
        public CarInfoBuilder WithType(string type)
        {
            Car.Type = type;
            return this;
        }
        public CarInfoBuilder WithColor(string color)
        {
            Car.Color = color;
            return this;
        }
        public CarInfoBuilder WithNumberOfDoors(int number)
        {
            Car.NumberOfDoors = number;
            return this;
        }
    }
}
