using System;
using System.Text;

namespace Animals
{
    public class Animal
    {
        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Sound { get; set; }

        public string ProduceSound()
            => Sound;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{GetType().Name}\n{Name} {Age} {Gender}\n{this.ProduceSound()}");
            return sb.ToString().TrimEnd();
        }
    }
}
