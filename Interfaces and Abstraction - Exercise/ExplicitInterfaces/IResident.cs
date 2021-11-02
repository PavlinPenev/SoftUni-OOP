namespace ExplicitInterfaces
{
    public interface IResident
    {
        string Name { get; set; }
        string Country { get; set; }
        string GetName();
    }
}
