namespace ArtfulAdventures.Web.ViewModels.Picture;

/// <summary>
///  "This is a view model used for displaying pictures in the Explore page!"
/// </summary>
public class PictureVisualizeViewModel
{
    public string Id { get; set; } = null!;

    /// <summary>
    /// "This is a property used for sorting purposes only, when the users wants to display picture by specific user!"
    /// </summary>
    public string Owner { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public int Likes { get; set; }

    public string PictureUrl { get; set; } = null!;

    public List<string> HashTags { get; set; } = new List<string>();
}

