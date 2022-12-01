
namespace Vehicles.Exceptions
{
    using System;
    public class InvalidVehicleTypeException : Exception
    {
        private const string DefaultMessage = "Vehicle type not supported!";

        public InvalidVehicleTypeException()
            : base(DefaultMessage)
        {

        }

        public InvalidVehicleTypeException(string message)
            : base(message)
        {

        }
    }
}
