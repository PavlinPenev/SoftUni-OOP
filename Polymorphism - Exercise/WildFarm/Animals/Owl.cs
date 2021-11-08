using System;
namespace WildFarm.Animals
{
    public class Owl : Bird
    {
        private const double WeightIncrease = 0.25;
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound()
            => "Hoot Hoot";
        public override void Eat(Food.Food food)
        {
            if (ValidateFood(food.GetType().Name))
            {
                Weight += WeightIncrease * food.Quantity;
                FoodEaten += food.Quantity;
            }
        }

        private bool ValidateFood(string food)
        {
            if (food == "Meat")
            {
                return true;
            }
            throw new InvalidOperationException($"{GetType().Name} does not eat {food}!");
        }
    }
}
