namespace ArtfulAdventures.Common;

/// <summary>
///  This class is used to store constants for the data models.
/// </summary>
public static class DataModelsValidationConstants
{
    /// <summary>
    ///  This class is used to store constants for the ApplicationUser data model.
    /// </summary>
    public static class ApplicationUserConstants
    {
        public const int UrlMinLength = 3;
        public const int UrlMaxLength = 2048;
        public const int NameMinLength = 3;
        public const int NameMaxLength = 70;
        public const int BioMinLength = 10;
        public const int BioMaxLength = 100;
        public const int CityNameMinLength = 3;
        public const int CityNameMaxLength = 60;
        public const int AboutMinLength = 10;
        public const int AboutMaxLength = 200;

    }
    
    /// <summary>
    ///  This class is used to store constants for the Blog data model.
    /// </summary>
    public static class BlogConstants
    {
        public const int TitleMinLength = 20;
        public const int TitleMaxLength = 100;
        public const int UrlMinLength = 3;
        public const int UrlMaxLength = 2048;
        public const int ContentMinLength = 100;
        public const int ContentMaxLength = 10000;
        public const string DateFormat = "yyyy-MM-dd H:mm";
    }

    /// <summary>
    ///  This class is used to store constants for the Comment data model.
    /// </summary>
    public static class CommentConstants
    {
        public const int AuthorMinLength = 5;
        public const int AuthorMaxLength = 50;
        public const int ContentMinLength = 10;
        public const int ContentMaxLength = 1000;
        public const string DateFormat = "yyyy-MM-dd H:mm";
    }

    /// <summary>
    ///  This class is used to store constants for the Challenge data model.
    /// </summary>
    public static class ChallengeConstants
    {
        public const int TitleMinLength = 20;
        public const int TitleMaxLength = 100;
        public const int CreatorMinLength = 5;
        public const int CreatorMaxLength = 50;
        public const int UrlMinLength = 3;
        public const int UrlMaxLength = 2048;
        public const int RequirementsMinLength = 20;
        public const int RequirementsMaxLength = 1000;
        public const string DateFormat = "yyyy-MM-dd H:mm";
    }

    /// <summary>
    ///  This class is used to store constants for the Picture data model.
    /// </summary>
    public static class PictureConstants
    {
        public const int UrlMinLength = 3;
        public const int UrlMaxLength = 2048;
        public const int DescriptionMinLength = 10;
        public const int DescriptionMaxLength = 1000;
        public const string DateFormat = "yyyy-MM-dd H:mm";
    }

    /// <summary>
    ///  This class is used to store constants for the Message data model.
    /// </summary>
    public static class MessageConstants
    {
        public const int SubjectMinLength = 2;
        public const int SubjectMaxLength = 100;
        public const int ContentMinLength = 10;
        public const int ContentMaxLength = 1000;
        public const string DateFormat = "yyyy-MM-dd H:mm";
    }

    /// <summary>
    ///  This class is used to store constants for the Roles.
    /// </summary>
    public static class RolesConstants
    {
        public const string AdminUserName = "admin";
        public const string AdminEmail = "admin@art-adv.com";
        public const string AdminPassword = "80d6f669-19f7-43d6-9a76-b6edd0be1a59";
        public const string AdminId = "2c5e174e-3b0e-446f-86af-483d56fd7210";
        public const string UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9";
    }
}
