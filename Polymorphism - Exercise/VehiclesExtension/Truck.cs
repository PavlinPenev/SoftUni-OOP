using System;

namespace VehiclesExtension
{
    public class Truck : IDrivable
    {
        private const double SummerFuelConsumptionModifier = 1.6;
        private const double TinyHoleInTankModifier = 0.95;
        private double _fuelConsumptionPerKm;
        public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            if (fuelQuantity <= TankCapacity)
            {
                FuelQuantity = fuelQuantity;
            }
            else
            {
                FuelQuantity = 0;
            }
            FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public double FuelQuantity { get; private set; }

        public double FuelConsumptionPerKm
        {
            get => _fuelConsumptionPerKm + SummerFuelConsumptionModifier;
            private set  => _fuelConsumptionPerKm = value;
        }

        public double TankCapacity { get; private set; }

        public void Drive(double distance)
        {
            if (FuelConsumptionPerKm * distance <= FuelQuantity)
            {
                FuelQuantity -= FuelConsumptionPerKm * distance;
                Console.WriteLine($"{GetType().Name} travelled {distance} km");
                return;
            }
            Console.WriteLine($"{GetType().Name} needs refueling");
        }

        public void Refuel(double amountFuel)
        {
            if (amountFuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            if (FuelQuantity + (amountFuel * TinyHoleInTankModifier) > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {amountFuel} fuel in the tank");
                return;
            }
            FuelQuantity = FuelQuantity + (amountFuel * TinyHoleInTankModifier);
        }
    }
}
