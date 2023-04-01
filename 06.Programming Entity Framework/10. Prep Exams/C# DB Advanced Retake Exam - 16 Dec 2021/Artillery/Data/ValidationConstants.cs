namespace Artillery.Data;

public class ValidationConstants
{
    //Country
    public const int CountryNameLengthMin = 4;
    public const int CountryNameLengthMax = 60;
    public const int CountryArmySizeRangeMin = 50000;
    public const int CountryArmySizeRangeMax = 10000000;

    //Manufacturer
    public const int ManufacturerNameLengthMin = 4;
    public const int ManufacturerNameLengthMax = 40;
    public const int ManufacturerFoundedLengthMin = 10;
    public const int ManufacturerFoundedLengthMax = 100;
}