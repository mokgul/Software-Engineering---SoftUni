namespace Homies.Data;

public static class DataValidationConstants
{
    public static class Event
    {
        public const int NameMinLength = 5;
        public const int NameMaxLength = 20;
        public const int DescriptionMinLength = 15;
        public const int DescriptionMaxLength = 150;
        public const string DateFormat = "yyyy-MM-dd H:mm";
    }

    public static class Type
    {
        public const int NameMinLength = 5;
        public const int NameMaxLength = 15;
    }
}

