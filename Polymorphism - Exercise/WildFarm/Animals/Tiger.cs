using System;

namespace WildFarm.Animals
{
    public class Tiger : Feline
    {
        private const double WeightIncrease = 1.0;
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
            => "ROAR!!!";

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
