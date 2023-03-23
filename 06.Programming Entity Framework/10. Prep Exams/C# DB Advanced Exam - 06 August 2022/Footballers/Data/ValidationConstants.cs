namespace Footballers.Data;

public class ValidationConstants
{
    //Coach
    public const int CoachNameLengthMin = 2;
    public const int CoachNameLengthMax = 40;

    //Footballer
    public const int FootballerNameLengthMin = 2;
    public const int FootballerNameLengthMax = 40;

    //Team
    public const string TeamNameValidationRegex = @"[A-Za-z\d\.\- ]{3,40}";
    public const int TeamNationalityLengthMin = 2;
    public const int TeamNationalityLengthMax = 40;
}