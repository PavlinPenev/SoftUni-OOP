using System;

namespace ExplicitInterfaces
{
    public class Citizen : IPerson, IResident
    {
        public Citizen(string name, int age, string country)
        {
            Name = name;
            Age = age;
            Country = country;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public string Country { get; set; }

        string IResident.GetName()
            => $"Mr/Ms/Mrs {Name}";

        string IPerson.GetName()
            => Name;

        public override string ToString()
            => $"{(this as IPerson).GetName()}{Environment.NewLine}{(this as IResident).GetName()}";
    }
}
