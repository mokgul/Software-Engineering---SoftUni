namespace ArtfulAdventures.Web.ViewModels.UserProfile;

using Picture;

/// <summary>
///  This is a view model for the portfolio / collection of pictures.
/// </summary>
public class PortfolioViewModel
{
    public ICollection<PictureVisualizeViewModel>? Pictures { get; set; }
}

