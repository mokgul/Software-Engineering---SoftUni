using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private double price;

        protected Cocktail(string name, string size, double price)
        {
            Name = name;
            Size = size;
            Price = price;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                name = value;
            }
        }
        public string Size { get; private set; }

        public double Price
        {
            get => price;
            private set
            {
                if (Size == "Large")
                    price = value;
                else if (Size == "Middle")
                    price = value * ((double)2 / 3.0);
                else if (Size == "Small")
                    price = value * ((double)1 / 3.0);
            }
        }

        public override string ToString()
            => $"{this.Name} ({this.Size}) - {this.Price:f2} lv";
    }
}
