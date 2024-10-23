
namespace VehiclesExtension.Exceptions
{
    public abstract class ExceptionMessages
    {
        public const string InsufficientFuelExceptionMessage =
            "{0} needs refueling";

        public const string UnableToFitFuelExceptionMessage =
            "Cannot fit {0} fuel in the tank";

        public const string InvalidFuelValueExceptionMessage =
            "Fuel must be a positive number";
    }
}
