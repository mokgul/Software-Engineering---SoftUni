namespace ArtfulAdventures.Web.ViewModels;

using HashTag;
using Picture;

/// <summary>
///  This class is used to visualize the Explore page.
/// </summary>
public class ExploreViewModel
{
    public ICollection<PictureVisualizeViewModel> Pictures { get; set; } = new List<PictureVisualizeViewModel>();

    public List<HashTagViewModel> HashTags { get; set; } = new List<HashTagViewModel>();

    public List<HashTagViewModel> TagsForDropDown { get; set; } = new List<HashTagViewModel>();
    
    
}

