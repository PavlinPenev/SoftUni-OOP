using System;

namespace VehiclesExtension
{
    public class Bus : IDrivable
    {
        private const double SummerFuelConsumptionModifier = 1.4;
        public Bus(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
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
        public double FuelConsumptionPerKm { get; private set; }
        public double TankCapacity { get; private set; }

        public void Drive(double distance)
        {
            if ((FuelConsumptionPerKm + SummerFuelConsumptionModifier) * distance <= FuelQuantity)
            {
                FuelQuantity -= (FuelConsumptionPerKm + SummerFuelConsumptionModifier) * distance;
                Console.WriteLine($"{GetType().Name} travelled {distance} km");
                return;
            }
            Console.WriteLine($"{GetType().Name} needs refueling");
        }

        public void DriveEmpty(double distance)
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
            if (FuelQuantity + amountFuel > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {amountFuel} fuel in the tank");
                return;
            }
            FuelQuantity += amountFuel;
        }
    }
}
