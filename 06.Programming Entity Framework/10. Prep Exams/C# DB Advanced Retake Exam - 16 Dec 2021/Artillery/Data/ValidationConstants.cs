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

    //Shell
    public const double ShellWeightValueMin = 2.0;
    public const double ShellWeightValueMax = 1680.0;
    public const int ShellCaliberSizeMin = 4;
    public const int ShellCaliberSizeMax = 30;

    //Guns
    public const int GunWeightValueMin = 100;
    public const int GunWeightValueMax = 1_350_000;
    public const double GunBarrelLengthMin = 2.0;
    public const double GunBarrelLengthMax = 35.0;
    public const int GunRangeValueMin = 1;
    public const int GunRangeValueMax = 100_000;
}