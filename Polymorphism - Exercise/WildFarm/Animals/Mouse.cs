using System;

namespace WildFarm.Animals
{
    public class Mouse : Mammal
    {
        private const double WeightIncrease = 0.1;
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override string ProduceSound()
            => "Squeak";

        public override void Eat(Food.Food food)
        {
            if (ValidateFood(food.GetType().Name))
            {
                Weight += WeightIncrease * food.Quantity;
                FoodEaten += food.Quantity;
            }
        }

        public override string ToString()
            => $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";

        private bool ValidateFood(string food)
        {
            if (food == "Vegetable" || food == "Fruit")
            {
                return true;
            }
            throw new InvalidOperationException($"{GetType().Name} does not eat {food}!");
        }
    }
}
