using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            try
            {
                Pizza currentPizza = null;
                while ((input = Console.ReadLine()) != "END")
                {
                        string[] ingredientInfo = input.Split();
                        switch (ingredientInfo[0])
                        {
                            case "Pizza":
                                string name = ingredientInfo[1];
                                currentPizza = new Pizza(name);
                                break;
                            case "Dough":
                                string flourType = ingredientInfo[1];
                                string bakingTechnique = ingredientInfo[2];
                                int doughWeight = int.Parse(ingredientInfo[3]);
                                Dough currentDough = new Dough(flourType, bakingTechnique, doughWeight);
                                currentDough.CalcCalories();
                                currentPizza.Dough = currentDough;
                                break;
                            case "Topping":
                                string toppingType = ingredientInfo[1];
                                int toppingWeight = int.Parse(ingredientInfo[2]);
                                Topping currenTopping = new Topping(toppingType, toppingWeight);
                                currenTopping.CalcCalories();
                                currentPizza.AddTopping(currenTopping);
                                break;
                        }
                }
                currentPizza.CalcCalories();
                Console.WriteLine(currentPizza);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
