using System;
using System.Linq;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double[] carInfo = Console.ReadLine().Split().Skip(1).Select(double.Parse).ToArray();
            double[] truckInfo = Console.ReadLine().Split().Skip(1).Select(double.Parse).ToArray();
            Car currentCar = new Car(carInfo[0], carInfo[1]);
            Truck currentTruck = new Truck(truckInfo[0], truckInfo[1]);
            int loopRotations = int.Parse(Console.ReadLine());
            for (int i = 0; i < loopRotations; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                string action = cmdArgs[0];
                string vehicleTypeToDoAction = cmdArgs[1];
                double distanceToDriveOrLitersToRefuel = double.Parse(cmdArgs[2]);
                switch (action)
                {
                    case "Drive":
                        if (vehicleTypeToDoAction == "Car")
                        {
                            currentCar.Drive(distanceToDriveOrLitersToRefuel);
                        }
                        else if (vehicleTypeToDoAction == "Truck")
                        {
                            currentTruck.Drive(distanceToDriveOrLitersToRefuel);
                        }
                        break;
                    case "Refuel":
                        if (vehicleTypeToDoAction == "Car")
                        {
                            currentCar.Refuel(distanceToDriveOrLitersToRefuel);
                        }
                        else if (vehicleTypeToDoAction == "Truck")
                        {
                            currentTruck.Refuel(distanceToDriveOrLitersToRefuel);
                        }

                        break;
                }
            }

            Console.WriteLine($"Car: {currentCar.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {currentTruck.FuelQuantity:f2}");
        }
    }
}
