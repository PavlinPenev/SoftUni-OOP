using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        private const string DefaultGender = "Female";
        public Kitten(string name, int age)
            : base(name, age, DefaultGender)
        {
            Sound = "Meow";
        }
    }
}
