using System;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] citizenInfo = input.Split();
                string name = citizenInfo[0];
                string country = citizenInfo[1];
                int age = int.Parse(citizenInfo[2]);
                Citizen currCitizen = new Citizen(name, age, country);
                Console.WriteLine(currCitizen);
            }
        }
    }
}
