using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Pizza
    {
        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }
        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public string Name
        {
            get => name;
            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length < 1 || value.Length > 15)
                    throw new ArgumentException(ExceptionMessages.INVALID_PIZZA_NAME);
                name = value;
            }
        }

        public Dough Dough
        {
            set => dough = value;
        }

        public bool TooManyToppings()
            => this.toppings.Count > 10
                ? throw new ArgumentException(ExceptionMessages.INVALID_NUMBER_TOPPINGS)
                : false; 
        public int Toppings => toppings.Count;

        public void AddTopping(Topping topping) => toppings.Add(topping);

        public double TotalCalories() => toppings.Sum(t => t.TotalCalories) + dough.TotalCalories;
        
    }
}
