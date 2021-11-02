using System;
using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class MyList : IAdd, IRemove
    {
        private List<string> elements;

        public MyList()
        {
            elements = new List<string>();
        }
        public int Used => elements.Count;
        public int Add(string element)
        {
            elements.Insert(0, element);
            return 0;
        }

        public string Remove()
        {
            string element = elements[0];
            elements.RemoveAt(0);
            return element;
        }
    }
}
