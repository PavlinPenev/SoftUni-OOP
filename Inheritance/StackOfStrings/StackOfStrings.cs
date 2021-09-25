using System.Collections.Generic;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
            => this.Count == 0;

        public Stack<string> AddRange(IEnumerable<string> collection)
        {
            foreach (var str in collection)
            {
                this.Push(str);
            }
            return this;
        }
    }
}
