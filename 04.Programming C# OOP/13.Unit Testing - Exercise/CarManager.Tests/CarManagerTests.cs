namespace CarManager.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Internal;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car _car;

        [SetUp]
        public void SetUp()
        {
            _car = new Car("Subaru", "Forester", 2.5, 35);
            //_cars = new Car[]
            //{
            //    new Car("Subaru", "Forester", 2.5, 35),
            //    new Car("Opel", "Astra", 3.4, 23),
            //    new Car("Volkswagen", "Gold", 4.1, 33),
            //    new Car("Audi", "A4", 3.7, 31)
            //    };
        }

        [Test]
        public void CarConstructorInitilizesFuelAmount()
        {
            double expectedFuelAmount = 0;
            Car car = new Car("Subaru", "Forester", 2.5, 35);
            double actualFuelAmount = car.FuelAmount;
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }


        [Test]
        public void ConstructorInitializesMakeCorrectly()
        {
            string expectedMake = "Subaru";
            Car car = new Car("Subaru", "Forester", 2.5, 35);
            string actualMake = car.Make;
            Assert.AreEqual(expectedMake, actualMake);
        }

        [Test]
        public void ConstructorInitializesModelCorrectly()
        {
            string expectedModel = "Forester";
            Car car = new Car("Subaru", "Forester", 2.5, 35);
            string actualModel = car.Model;
            Assert.AreEqual(expectedModel, actualModel);
        }

        [Test]
        public void ConstructorInitializesFuelConsumptionCorrectly()
        {
            double expectedFuelConsumption = 2.5;
            Car car = new Car("Subaru", "Forester", 2.5, 35);
            double actualFuelConsumption = car.FuelConsumption;
            Assert.AreEqual(expectedFuelConsumption, actualFuelConsumption);
        }

        [Test]
        public void ConstructorInitializesFuelCapacityCorrectly()
        {
            double expectedFuelCapacity = 35;
            Car car = new Car("Subaru", "Forester", 2.5, 35);
            double actualFuelCapacity = car.FuelCapacity;
            Assert.AreEqual(expectedFuelCapacity, actualFuelCapacity);
        }

        [Test]
        public void MakeSetterReturnsProperValue()
        {
            string expectedMake = "Subaru";
            string actualMake = _car.Make;
            Assert.AreEqual(expectedMake, actualMake);
        }

        [TestCase(null)]
        [TestCase("")]
        public void MakeSetterShouldThrowExceptionWithInvalidParameter(string make)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, "Forester", 2.5, 35);
            });
        }

        [Test]
        public void ModelSetterReturnsProperValue()
        {
            string expectedModel = "Forester";
            string actualModel = _car.Model;
            Assert.AreEqual(expectedModel, actualModel);
        }

        [TestCase(null)]
        [TestCase("")]
        public void ModelSetterShouldThrowExceptionWithInvalidParameter(string model)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Subaru", model, 2.5, 35);
            });
        }

        [Test]
        public void FuelConsumptionSetterReturnsProperValue()
        {
            double expectedFuelConsumption = 2.5;
            double actualFuelConsumption = _car.FuelConsumption;
            Assert.AreEqual(expectedFuelConsumption, actualFuelConsumption);
        }

        [TestCase(-1)]
        [TestCase(-0.003)]
        [TestCase(0)]
        public void FuelConsumptionSetterShouldThrowExceptionWithZeroOrNegative(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Subaru", "Forester", fuelConsumption, 35);
            });
        }

        [Test]
        public void FuelCapacitySetterReturnsProperValue()
        {
            double expectedFuelCapacity = 35;
            double actualCapacity = _car.FuelCapacity;
            Assert.AreEqual(expectedFuelCapacity, actualCapacity);
        }

        [TestCase(-1)]
        [TestCase(-0.003)]
        public void FuelCapacitySetterShouldThrowExceptionWithNegative(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Subaru", "Forester", 2.5, fuelCapacity);
            });
        }

        [TestCase(10)]
        [TestCase(20)]
        [TestCase(35)]
        public void RefuelMethodWithValuesBelowCapacity(double fuelAmount)
        {
            double expectedFuelAmount = fuelAmount;
            _car.Refuel(fuelAmount);
            double actualFuelAmount = _car.FuelAmount;
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [TestCase(36)]
        [TestCase(45)]
        [TestCase(75)]
        public void RefuelMethodWithValuesAboveCapacity(double fuelAmount)
        {
            double expectedFuelAmount = _car.FuelCapacity;
            _car.Refuel(fuelAmount);
            double actualFuelAmount = _car.FuelAmount;
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [TestCase(-1)]
        [TestCase(-0.003)]
        [TestCase(0)]
        public void RefuelMethodWithValuesZeroOrNegative(double fuelAmount)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _car.Refuel(fuelAmount);
            });
        }

        [TestCase(25.50)]
        [TestCase(50)]
        [TestCase(83.50)]
        public void DriveMethodWithEnoughFuelShouldUpdateFuelAmountProperly(double distance)
        {
            _car.Refuel(35);
            double fuelNeeded = (distance / 100) * _car.FuelConsumption;
            double expectedFuelAmount = _car.FuelAmount - fuelNeeded;
            _car.Drive(distance);
            double actualFuelAmount = _car.FuelAmount;
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }

        [TestCase(10000)]
        [TestCase(50000)]
        public void DriveMethodWithNotEnoughFuelShouldThrowException(double distance)
        {
            _car.Refuel(13);
            Assert.Throws<InvalidOperationException>(() =>
            {
                _car.Drive(distance);
            });
        }
    }
}