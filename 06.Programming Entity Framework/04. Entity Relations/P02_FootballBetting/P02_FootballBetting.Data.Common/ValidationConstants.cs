namespace P02_FootballBetting.Data.Common;

public class ValidationConstants
{
    //Team
    public const int TeamNameMaxLength = 64;
    public const int TeamLogoUrlLength = 255;
    public const int TeamInitialsLength = 5;

    //Color
    public const int ColorNameLength = 10;

    //Town
    public const int TownNameLength = 60;

    //Country
    public const int CountryNameLength = 60;

    //Player
    public const int PlayerNameMaxLength = 100;

    //Position
    public const int PositionNameMaxLength = 50;

    //Game
    public const int GameResultMaxLength = 7;

    //User
    public const int UsernameMaxLength = 50;
    public const int PasswordMaxLength = 255;
    public const int EmailMaxLength = 255;
    public const int NameMaxLength = 100;
}