using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] peopleAndTheirMoney = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, Person> people = new Dictionary<string, Person>();
            string[] productsAndTheirPrice = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, Product> products = new Dictionary<string, Product>();
            string input;
            try
            {
                foreach (var person in peopleAndTheirMoney)
                {
                    string[] personInfo = person.Split('=');
                    string name = personInfo[0];
                    decimal money = decimal.Parse(personInfo[1]);
                    Person currentPerson = new Person(name, money);
                    if (!people.ContainsKey(name))
                    {
                        people.Add(name, currentPerson);
                    }
                }

                foreach (var product in productsAndTheirPrice)
                {
                    string[] productInfo = product.Split('=');
                    string name = productInfo[0];
                    decimal cost = decimal.Parse(productInfo[1]);
                    Product currentProduct = new Product(name, cost);
                    if (!products.ContainsKey(name))
                    { 
                        products.Add(name, currentProduct);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            while ((input = Console.ReadLine()) != "END")
            {
                string[] personBuysProduct = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string personName = personBuysProduct[0];
                string productName = personBuysProduct[1];
                if (people.ContainsKey(personName) && products.ContainsKey(productName))
                {
                    try
                    {
                        people[personName].Buy(products[productName]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }

            foreach (var person in people)
            {
                Console.WriteLine(person.Value);
            }
        }
    }
}
