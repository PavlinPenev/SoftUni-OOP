using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private IReadOnlyList<Topping> toppings;
        private double totalCalories;

        public Pizza(string name)
        {
            Name = name;
            Toppings = new List<Topping>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }

        public Dough Dough
        {
            get => dough;
            set
            {
                dough = value;
            }
        }

        public IReadOnlyList<Topping> Toppings
        {
            get => toppings;
            private set
            {
                if (toppings != null)
                {
                    if (toppings.Count > 10)
                    {
                        throw new Exception("Number of toppings should be in range [0..10].");
                    }
                }
                toppings = value;
            }
        }

        public double TotalCalories
        {
            get => totalCalories;
            private set
            {
                totalCalories = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            List<Topping> toppings = Toppings.ToList();
            toppings.Add(topping);
            Toppings = toppings.AsReadOnly();
        }

        public void CalcCalories()
        {
            TotalCalories = Toppings.Select(t => t.CaloriesPerGram).Sum() + this.dough.CaloriesPerGram;
        }

        public override string ToString()
            => $"{Name} - {TotalCalories:f2} Calories.";
    }
}
