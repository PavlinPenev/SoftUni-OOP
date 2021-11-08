using System;
using System.Collections.Generic;
using WildFarm.Animals;
using WildFarm.Food;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            List<Animal> animals = new List<Animal>();
            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalInfo = input.Split();
                string[] foodInfo = Console.ReadLine().Split();
                string animalType = animalInfo[0];
                string animalName = animalInfo[1];
                double animalWeight = double.Parse(animalInfo[2]);
                string foodType = foodInfo[0];
                int foodQuantity = int.Parse(foodInfo[1]);
                Animal currentAnimal = null;
                switch (animalType)
                {
                    case "Owl":
                        double wingSize = double.Parse(animalInfo[3]);
                        currentAnimal = new Owl(animalName, animalWeight, wingSize);
                        break;
                    case "Hen":
                        wingSize = double.Parse(animalInfo[3]);
                        currentAnimal = new Hen(animalName, animalWeight, wingSize);
                        break;
                    case "Mouse":
                        string livingRegion = animalInfo[3];
                        currentAnimal = new Mouse(animalName, animalWeight, livingRegion);
                        break;
                    case "Dog":
                        livingRegion = animalInfo[3];
                        currentAnimal = new Dog(animalName, animalWeight, livingRegion);
                        break;
                    case "Cat":
                        livingRegion = animalInfo[3];
                        string breed = animalInfo[4];
                        currentAnimal = new Cat(animalName, animalWeight, livingRegion, breed);
                        break;
                    case "Tiger":
                        livingRegion = animalInfo[3];
                        breed = animalInfo[4];
                        currentAnimal = new Tiger(animalName, animalWeight, livingRegion, breed);
                        break;
                }

                Food.Food currentFood = null;
                switch (foodType)
                {
                    case "Fruit":
                        currentFood = new Fruit(foodQuantity);
                        break;
                    case "Meat":
                        currentFood = new Meat(foodQuantity);
                        break;
                    case "Seeds":
                        currentFood = new Seeds(foodQuantity);
                        break;
                    case "Vegetable":
                        currentFood = new Vegetable(foodQuantity);
                        break;
                }

                Console.WriteLine(currentAnimal.ProduceSound());
                try
                {
                    currentAnimal.Eat(currentFood);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                animals.Add(currentAnimal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
