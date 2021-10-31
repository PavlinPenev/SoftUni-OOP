namespace BorderControl
{
    public class Rebel : IBuyer // 6.Food Shortage
    {
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }
        public int Food { get; private set; } = 0;

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
