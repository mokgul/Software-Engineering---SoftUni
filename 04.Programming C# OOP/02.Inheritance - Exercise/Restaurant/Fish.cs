using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Fish : MainDish
    {
        private const double grams = 22;
        public Fish(string name, decimal price) : base(name, price, grams)
        {
        }
    }
}
