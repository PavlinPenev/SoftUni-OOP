using System;

namespace WildFarm.Animals
{
    public class Cat : Feline
    {
        private const double WeightIncrease = 0.3;
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
            => "Meow";

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
            if (food == "Vegetable" || food == "Meat")
            {
                return true;
            }
            throw new InvalidOperationException($"{GetType().Name} does not eat {food}!");
        }
    }
}
