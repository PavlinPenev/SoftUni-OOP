using System.Reflection.Metadata;

namespace BorderControl
{
    public class Pet : ICelebratable // 5.Birthday Celebrations
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; set; }
        public string Birthdate { get; set; }
    }
}
