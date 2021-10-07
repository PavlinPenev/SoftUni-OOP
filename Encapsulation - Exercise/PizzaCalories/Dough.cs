using System;

namespace PizzaCalories
{
    public class Dough
    {
        private const double WhiteModifier = 1.5;
        private const double WholegrainModifier = 1.0;
        private const double CrispyModifier = 0.9;
        private const double ChewyModifier = 1.1;
        private const double HomemadeModifier = 1.0;
        private const double ModifierPerGram = 2;

        private string flourType;
        private string bakingTechnique;
        private int weight;
        private double caloriesPerGram;

        


        public Dough(string flourType, string bakingTechnique, int weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

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

        public int Weight
        {
            get
            {
                return weight;
            }
            private set
            {
                if (value < 0 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range[1..200].");

                }
                weight = value;
            }
        }


        public string BakingTechnique
        {
            get
            {
                return bakingTechnique;
            }
            private set
            {
                if (String.Compare(value, "Crispy", StringComparison.OrdinalIgnoreCase) == 0
                || String.Compare(value, "Chewy", StringComparison.OrdinalIgnoreCase) == 0
                || String.Compare(value, "Homemade", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    bakingTechnique = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }

        public string FlourType
        {
            get
            {
                return flourType;
            }
            private set
            {
                if (String.Compare(value, "White", StringComparison.OrdinalIgnoreCase) == 0
                || String.Compare(value, "Wholegrain", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    flourType = value;
                }
                else
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
            }
        }

        public void CalcCalories()
        {
            double modifierFlour = 0;
            double modifierTechnique = 0;
            if (String.Compare(FlourType, "White", StringComparison.OrdinalIgnoreCase) == 0)
            {
                modifierFlour = WhiteModifier;
            }
            else if (String.Compare(FlourType, "Wholegrain", StringComparison.OrdinalIgnoreCase) == 0)
            {
                modifierFlour = WholegrainModifier;
            }

            if (String.Compare(BakingTechnique, "Crispy", StringComparison.OrdinalIgnoreCase) == 0)
            {
                modifierTechnique = CrispyModifier;
            }
            else if (String.Compare(BakingTechnique, "Chewy", StringComparison.OrdinalIgnoreCase) == 0)
            {
                modifierTechnique = ChewyModifier;
            }
            else if (String.Compare(BakingTechnique, "Homemade", StringComparison.OrdinalIgnoreCase) == 0)
            {
                modifierTechnique = HomemadeModifier;
            }

            caloriesPerGram = (ModifierPerGram * Weight) * modifierFlour * modifierTechnique;
        }

    }
}
