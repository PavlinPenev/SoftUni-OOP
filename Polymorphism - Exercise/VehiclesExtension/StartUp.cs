using System;
using System.Linq;

namespace VehiclesExtension
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double[] carInfo = Console.ReadLine().Split().Skip(1).Select(double.Parse).ToArray();
            double[] truckInfo = Console.ReadLine().Split().Skip(1).Select(double.Parse).ToArray();
            double[] busInfo = Console.ReadLine().Split().Skip(1).Select(double.Parse).ToArray();
            Car currentCar = new Car(carInfo[0], carInfo[1], carInfo[2]);
            Truck currentTruck = new Truck(truckInfo[0], truckInfo[1], truckInfo[2]);
            Bus currentBus = new Bus(busInfo[0], busInfo[1], busInfo[2]);
            int loopRotations = int.Parse(Console.ReadLine());
            for (int i = 0; i < loopRotations; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                string action = cmdArgs[0];
                string vehicleToDoAction = cmdArgs[1];
                double distanceToDriveOrFuelToRefuel = double.Parse(cmdArgs[2]);
                switch (action)
                {
                    case "Drive":
                        if (vehicleToDoAction == "Car")
                        {
                            currentCar.Drive(distanceToDriveOrFuelToRefuel);
                        }
                        else if (vehicleToDoAction == "Truck")
                        {
                            currentTruck.Drive(distanceToDriveOrFuelToRefuel);
                        }
                        else if (vehicleToDoAction == "Bus")
                        {
                            currentBus.Drive(distanceToDriveOrFuelToRefuel);
                        }
                        break;
                    case "DriveEmpty":
                        currentBus.DriveEmpty(distanceToDriveOrFuelToRefuel);
                        break;
                    case "Refuel":
                        if (vehicleToDoAction == "Car")
                        {
                            currentCar.Refuel(distanceToDriveOrFuelToRefuel);
                        }
                        else if (vehicleToDoAction == "Truck")
                        {
                            currentTruck.Refuel(distanceToDriveOrFuelToRefuel);
                        }
                        else if (vehicleToDoAction == "Bus")
                        {
                            currentBus.Refuel(distanceToDriveOrFuelToRefuel);
                        }
                        break;
                }
            }

            Console.WriteLine($"Car: {currentCar.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {currentTruck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {currentBus.FuelQuantity:f2}");
        }
    }
}
