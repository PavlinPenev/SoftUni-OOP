namespace VehiclesExtension
{
    public interface IDrivable
    {
        double FuelQuantity { get; }
        double FuelConsumptionPerKm { get; }
        double TankCapacity { get; }
        void Drive(double distance);
        void Refuel(double amountFuel);
    }
}
