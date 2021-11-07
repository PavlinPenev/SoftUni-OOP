namespace Vehicles
{
    public interface IDrivable
    {
        double FuelQuantity { get; }
        double FuelConsumptionPerKm { get; }
        void Drive(double distance);
        void Refuel(double amountFuel);

    }
}
