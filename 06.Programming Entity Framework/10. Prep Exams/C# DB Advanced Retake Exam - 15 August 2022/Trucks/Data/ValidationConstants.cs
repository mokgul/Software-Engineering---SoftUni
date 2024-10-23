namespace Trucks.Data;

public class ValidationConstants
{
    //Truck Validation
    public const int RegistrationNumberLength = 8;
    public const int VinNumberLength = 17;
    public const int TankCapacityMinRange = 950;
    public const int TankCapacityMaxRange = 1420;
    public const int CargoCapacityMinRange = 5000;
    public const int CargoCapacityMaxRange = 29000;
    public const int CategoryTypeRangeValueMin = 0;
    public const int CategoryTypeRangeValueMax = 3;
    public const int MakeTypeRangeValueMin = 0;
    public const int MakeTypeRangeValueMax = 4;

    //Client Validation
    public const int ClientNameMinLength = 3;
    public const int ClientNameMaxLength = 40;
    public const int NationalityMinLength = 2;
    public const int NationalityMaxLength = 40;

    //Despatcher Validation
    public const int DespatcherNameMaxLength = 40;
    public const int DespatcherNameMinLength = 2;
}