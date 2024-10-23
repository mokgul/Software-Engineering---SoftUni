using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty() => this.Count == 0;

        public Stack<string> AddRange(Stack<string> range)
        {
            foreach (var item in range)
            {
                this.Push(item);
            }
            return this;
        }
    }
}
