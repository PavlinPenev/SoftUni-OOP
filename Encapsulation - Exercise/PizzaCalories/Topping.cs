using System;

namespace PizzaCalories
{
    public class Topping
    { 
        private const double MeatModifier = 1.2;
        private const double VeggiesModifier = 0.8;
        private const double CheeseModifier = 1.1;
        private const double SauceModifier = 0.9;
        private const double ModifierPerGram = 2;

        private string type;
        private int weight;
        private double caloriesPerGram;

        public double CaloriesPerGram
        {
            get
            {
                return caloriesPerGram;
            }
            private set
            {
                caloriesPerGram = value;
            }
        }


        public Topping(string type, int weight)
        {
            Type = type;
            Weight = weight;
        }
        public int Weight
        {
            get
            {
                return weight;
            }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }


        public string Type
        {
            get { return type; }
            private set
            {
                if (String.Compare(value, "Meat", StringComparison.OrdinalIgnoreCase) == 0 
                    || String.Compare(value, "Veggies", StringComparison.OrdinalIgnoreCase) == 0
                    || String.Compare(value, "Cheese", StringComparison.OrdinalIgnoreCase) == 0
                    || String.Compare(value, "Sauce", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    type = value;
                }
                else
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

            }
        }

        public void CalcCalories()
        {
            double modifier = 0;
            switch (Type.ToLower())
            {
                case "meat":
                    modifier = MeatModifier;
                    break;
                case "veggies":
                    modifier = VeggiesModifier;
                    break;
                case "cheese":
                    modifier = CheeseModifier;
                    break;
                case "sauce":
                    modifier = SauceModifier;
                    break;
            }

            CaloriesPerGram = ModifierPerGram * Weight * modifier;
        }
    }
}
