namespace ArtfulAdventures.Services.Common;

/// <summary>
/// Validates the page number
/// </summary>
public static class ValidatePage
{
    /// <summary>
    /// Validates the page number
    /// </summary>
    /// <param name="page"></param>
    /// <returns> Returns true if the page number is valid, otherwise false </returns>
    public static bool Validate(int page)
    {
        return page >= 1;
    }
}