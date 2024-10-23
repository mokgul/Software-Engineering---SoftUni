namespace ArtfulAdventures.Common;

/// <summary>
///   General application constants
/// </summary>
public static class GeneralApplicationConstants
{
    
    public const int releaseYear = 2023;
    
    /// <summary>
    ///  Constant for the ftp server
    /// </summary>
    public const string ftpServerUrl = $"ftp://fsc-avconsulting.ch/";
    
    /// <summary>
    ///  Constant for the ftp server's username.
    /// </summary>
    public const string ftpUserName = $"SHIN-MEDIA\\ArtfulFTP";
    
    /// <summary>
    ///  Constant for the ftp server's password.
    /// </summary>
    public const string ftpPassword = $"R8J5!dmcnGcu5LB";
    
    /// <summary>
    ///  Constant for the ftp server's port.
    /// </summary>
    public const int ftpPort = 50022;

    public const string defaultPictureDescriptionChallenge = "Challenge participation";

    /// <summary>
    ///  Constants for the application's roles
    /// </summary>
    public static class Roles
    {
        public const string Administrator = "Administrator";
        public const string User = "User";
    }
}
