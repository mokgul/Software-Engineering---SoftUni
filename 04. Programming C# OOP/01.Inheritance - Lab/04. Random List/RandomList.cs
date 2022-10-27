using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private readonly Random _random;

        public RandomList()
        {
            _random = new Random();
        }

        public string RandomString()
        {
            int index =_random.Next(0, Count);
            string removed = this[index];
            this.RemoveAt(index);
            return removed;
        }
    }
}
