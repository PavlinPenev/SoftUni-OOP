using System;
using NUnit.Framework;

namespace CarManager.Tests
{
    public class CarTests
    {
        private Car _testCar;

        [SetUp]
        public void Setup()
        {
            _testCar = new Car("Audi", "A4", 11.0, 65.0);
        }

        [Test] //Test Constructors
        public void BothConstructorsShouldCreateInstanceWithProperParameters()
        {
            bool assertCondition = _testCar.Make == "Audi" && _testCar.Model == "A4" &&
                                   _testCar.FuelConsumption == 11.0 && _testCar.FuelCapacity == 65.0 &&
                                   _testCar.FuelAmount == 0;
            Assert.AreEqual(true, assertCondition);
        }

        [Test] //Test properties(getters, setters)
        public void PropertiesGettersAndSettersShouldWorkCorrectly()
        {
            Assert.AreEqual("Audi", _testCar.Make);
            Assert.AreEqual("A4", _testCar.Model);
            Assert.AreEqual(11.0, _testCar.FuelConsumption);
            Assert.AreEqual(65.0, _testCar.FuelCapacity);
            Assert.AreEqual(0, _testCar.FuelAmount);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void MakePropertySetterShouldValidateProperlyAndThrowException(string makeModel)
        {
            Assert.Throws<ArgumentException>(() => new Car(makeModel, "A4", 11.0, 65.0));
            Assert.Throws<ArgumentException>(() => new Car("Audi", makeModel, 11.0, 65.0));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-5.0)]
        public void FuelConsumptionSetterShouldValidateProperlyAndThrowException(double value)
        {
            Assert.Throws<ArgumentException>(() => new Car("Audi", "A4", value, 65.0));
            Assert.Throws<ArgumentException>(() => new Car("Audi", "A4", 11.0, value));
        }

        [Test] //Test methods and validations
        [TestCase(30)]
        [TestCase(70)]

        public void RefuelMethodShouldWorkProperly(double fuel)
        {
            _testCar.Refuel(fuel);
            if (fuel > _testCar.FuelCapacity)
            {
                fuel = _testCar.FuelCapacity;
            }
            Assert.AreEqual(fuel, _testCar.FuelAmount);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-25)]
        public void RefuelMethodShouldThrowExceptionForNegativeValuesOfFuelParameter(double fuel)
        {
            Assert.Throws<ArgumentException>(() => _testCar.Refuel(fuel));
        }

        [Test]
        public void DriveMethodShouldWorkCorrectly()
        {
            _testCar.Refuel(65);
            _testCar.Drive(10);
            Assert.AreEqual(63.9, _testCar.FuelAmount);
        }

        [Test]
        public void DriveMethodShouldThrowExceptionIfFuelNeededIsMoreThanFuelAmount()
        {
            _testCar.Refuel(10);
            Assert.Throws<InvalidOperationException>(() => _testCar.Drive(100));
        }
    }
}