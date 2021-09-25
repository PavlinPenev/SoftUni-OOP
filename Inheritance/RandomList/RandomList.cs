using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random rand = new Random();
            int index = rand.Next(0, this.Count - 1);
            string str = this[index];
            this.RemoveAt(index);
            return str;
        }
    }
}
