
using System;

namespace WildFarm.Exceptions
{
    public class InvalidTypeOfFoodException : Exception
    {
        private const string InvalidFood = "Invalid food type!";
        public InvalidTypeOfFoodException() : base(InvalidFood)
        {
            
        }
    }
}
