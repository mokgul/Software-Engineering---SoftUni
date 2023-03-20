namespace SoftJail.Data.Models;

public class ValidationConstants
{
    //Department
    public const int DepartmentNameMinLength = 3;
    public const int DepartmentNameMaxLength = 25;

    //Cell
    public const int CellNumberValueRangeMin = 1;
    public const int CellNumberValueRangeMax = 1000;

    //Prisoner
    public const int PrisonerFullNameMinLength = 3;
    public const int PrisonerFullNameMaxLength = 20;
    public const int PrisonerAgeValueRangeMin = 18;
    public const int PrisonerAgeValueRangeMax = 65;

    //Officer
    public const int OfficerFullNameMinLength = 3;
    public const int OfficerFullNameMaxLength = 30;
    public const int OfficerPositionMaxEnumValue = 3;
    public const int OfficerWeaponMaxEnumValue = 4;
}