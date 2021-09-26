namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string name, int age, string gender)
            : base(name, age, gender)
        {
            Sound = "Meow meow";
        }
    }
}
