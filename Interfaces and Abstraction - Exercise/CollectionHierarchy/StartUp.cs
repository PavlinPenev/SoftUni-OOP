using System;
using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemCollection = new AddRemoveCollection();
            MyList myListCollection = new MyList();
            string[] strings = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<int> addCollResults = new List<int>();
            List<int> addRemCollResults = new List<int>();
            List<int> myListResults = new List<int>();
            foreach (var s in strings)
            {
                addCollResults.Add(addCollection.Add(s));
                addRemCollResults.Add(addRemCollection.Add(s));
                myListResults.Add(myListCollection.Add(s));
            }

            int numberOfRemovals = int.Parse(Console.ReadLine());
            List<string> addRemCollRemoveResults = new List<string>();
            List<string> myListRemoveResults = new List<string>();
            for (int i = 0; i < numberOfRemovals; i++)
            {
                addRemCollRemoveResults.Add(addRemCollection.Remove());
                myListRemoveResults.Add(myListCollection.Remove());
            }

            Console.WriteLine(string.Join(" ", addCollResults));
            Console.WriteLine(string.Join(" ", addRemCollResults));
            Console.WriteLine(string.Join(" ", myListResults));
            Console.WriteLine(string.Join(" ", addRemCollRemoveResults));
            Console.WriteLine(string.Join(" ", myListRemoveResults));
        }
    }
}
