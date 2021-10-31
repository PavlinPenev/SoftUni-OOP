namespace PersonInfo
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;                   // 2. Multiple Implementation
            Birthdate = birthdate;     // 2. Multiple Implementation
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }         // 2. Multiple Implementation
        public string Birthdate { get; set; }  // 2. Multiple Implementation
    }
}
