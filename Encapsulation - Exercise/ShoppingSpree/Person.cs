using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<Product>();
        }

        public List<Product> BagOfProducts
        {
            get { return bagOfProducts; }
            private set { bagOfProducts = value; }
        }


        public decimal Money
        {
            get { return money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }


        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public void Buy(Product product)
        {
            if (Money < product.Cost)
            {
                throw new InvalidOperationException($"{Name} can't afford {product.Name}");

            }

            Money -= product.Cost;
            BagOfProducts.Add(product);
            Console.WriteLine($"{Name} bought {product.Name}");
            
            
        }

        public override string ToString()
            => $"{Name} - {(BagOfProducts.Any() ? string.Join(", ", BagOfProducts) : "Nothing bought")}";
    }
}
