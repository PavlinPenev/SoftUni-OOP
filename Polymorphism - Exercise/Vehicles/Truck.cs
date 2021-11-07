using System;

namespace Vehicles
{
    public class Truck : IDrivable
    {
        private const double SummerFuelConsumptionModifier = 1.6;
        private const double TinyHoleInTankModifier = 0.95;
        private double _fuelConsumptionPerKm;
        public Truck(double fuelQuantity, double fuelConsumptionPerKm)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public double FuelQuantity { get; private set; }

        public double FuelConsumptionPerKm
        {
            get => _fuelConsumptionPerKm + SummerFuelConsumptionModifier;
            private set  => _fuelConsumptionPerKm = value;
        }
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
            FuelQuantity = FuelQuantity + (amountFuel * TinyHoleInTankModifier);
        }
    }
}
