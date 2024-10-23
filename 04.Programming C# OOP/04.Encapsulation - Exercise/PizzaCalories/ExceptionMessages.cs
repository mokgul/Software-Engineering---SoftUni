using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class ExceptionMessages
    {
        public static string INVALID_TYPE_DOUGH = "Invalid type of dough.";
        public static string INVALID_WEIGHT_DOUGH = "Dough weight should be in the range [1..200].";
        public static string INVALID_TOPPING_TYPE = "Cannot place {0} on top of your pizza.";
        public static string INVALID_TOPPING_WEIGHT = "{0} weight should be in the range [1..50].";
        public static string INVALID_PIZZA_NAME = "Pizza name should be between 1 and 15 symbols.";
        public static string INVALID_NUMBER_TOPPINGS = "Number of toppings should be in range [0..10].";
    }
}
