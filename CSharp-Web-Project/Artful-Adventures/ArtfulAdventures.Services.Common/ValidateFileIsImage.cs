namespace ArtfulAdventures.Services.Common;

using Microsoft.AspNetCore.Http;

/// <summary>
/// Validates if the file is an image
/// </summary>
public class ValidateFileIsImage
{
    /// <summary>
    /// Validates if the file is an image
    /// </summary>
    /// <param name="file"></param>
    /// <returns> True if the file is an image, false if not </returns>
    public bool Validate(IFormFile file)
    {
        // Check if the file is an image
        var allowedContentTypes = new[] { "image/jpeg", "image/png", "image/gif" };
        return allowedContentTypes.Contains(file.ContentType);
    }
}