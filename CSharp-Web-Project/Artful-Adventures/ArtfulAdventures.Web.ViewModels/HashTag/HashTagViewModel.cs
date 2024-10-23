namespace ArtfulAdventures.Web.ViewModels.HashTag;

/// <summary>
///  This view model is used when displaying all hashtags.
/// </summary>
public class HashTagViewModel
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int PicturesCount { get; set; }

    public bool IsSelected { get; set; }
}

