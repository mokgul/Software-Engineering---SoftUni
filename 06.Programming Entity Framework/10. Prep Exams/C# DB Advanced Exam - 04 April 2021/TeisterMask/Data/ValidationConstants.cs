namespace TeisterMask.Data;

public class ValidationConstants
{
    //Project
    public const int ProjectNameLengthMin = 2;
    public const int ProjectNameLengthMax = 40;

    //Task
    public const int TaskNameLengthMin = 2;
    public const int TaskNameLengthMax = 40;

    //Username
    public const string UsernameValidation = @"[A-Za-z\d]{3,40}";
    public const string PhoneValidation = @"\d{3}-\d{3}-\d{4}";
}