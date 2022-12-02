
using System;

namespace WildFarm.Exceptions
{
    public class InvalidTypeOfAnimalException : Exception
    {
        private const string InvalidAnimal = "Invalid animal type!";
        public InvalidTypeOfAnimalException() : base(InvalidAnimal)
        {
            
        }
    }
}
