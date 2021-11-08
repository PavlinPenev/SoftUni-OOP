namespace WildFarm.Animals
{
    public class Hen : Bird
    {
        private const double WeightIncrease = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }
        
        public override string ProduceSound()
            => "Cluck";

        public override void Eat(Food.Food food)
        {
            Weight += WeightIncrease * food.Quantity;
            FoodEaten += food.Quantity;
        }
    }
}
