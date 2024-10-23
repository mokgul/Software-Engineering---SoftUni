namespace ArtfulAdventures.Services.Data;

using Web.ViewModels.Picture;

/// <summary>
///  This class is used to filter out broken urls from the database.
/// </summary>
public static class FilterBrokenUrls
{
    /// <summary>
    ///  This method filters out broken urls from the database.
    /// </summary>
    /// <param name="pictures"> The pictures to be filtered. </param>
    /// <returns> The filtered pictures. </returns>
    public static List<PictureVisualizeViewModel> FilterAsync(List<PictureVisualizeViewModel> pictures)
    {
        string?[] files = Directory.GetFiles(@"wwwroot\images");
        files = files.Select(Path.GetFileName).ToArray();
        
        return pictures.Where(picture => files.Contains(picture.PictureUrl)).ToList();
    }
}

